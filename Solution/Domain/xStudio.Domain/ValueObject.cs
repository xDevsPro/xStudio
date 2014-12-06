using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace xStudio.Domain
{
    public abstract class ValueObject
    {
        private static readonly
            ConcurrentDictionary<Type, Tuple<Func<ValueObject, ValueObject, bool>, Func<ValueObject, int>>> Cache =
                new ConcurrentDictionary<Type, Tuple<Func<ValueObject, ValueObject, bool>, Func<ValueObject, int>>>();
        private static Func<ValueObject, ValueObject, bool> BuildEqualsFunction(Type type)
        {
            // type p1
            var p1 = Expression.Parameter(type, "p1");
            // type p2
            var p2 = Expression.Parameter(type, "p2");
            // p1.PropA == p2.PropA, p1.PropB == p2.PropB
            var equals =
                type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Select(
                        t => Expression.Equal(
                            Expression.MakeMemberAccess(p1, t),
                            Expression.MakeMemberAccess(p2, t)))
                    .ToList();

            // (p1, p2) => p1.PropA == p2.PropA && p1.PropB == p2.PropB && true
            var lambda =
                Expression.Lambda(
                    equals.Aggregate<Expression, Expression>(
                        Expression.Constant(true),
                        (t, current) => Expression.AndAlso(current, t)),
                    p1,
                    p2);

            // ValueObject t1
            var t1 = Expression.Parameter(typeof(ValueObject), "t1");
            // ValueObject t2
            var t2 = Expression.Parameter(typeof(ValueObject), "t2");
            // lambda((type) t1, (type) t2)
            var castingCall =
                Expression.Invoke(
                    lambda,
                    Expression.Convert(t1, type),
                    Expression.Convert(t2, type));

            // (t1, t2) => lambda((type) t1, (type) t2)
            var result =
                Expression.Lambda<Func<ValueObject, ValueObject, bool>>(
                    castingCall,
                    t1,
                    t2);

            return result.Compile();
        }
        private static Func<ValueObject, int> BuildHashCodeFunction(Type type)
        {
            // type p
            var p = Expression.Parameter(type, "p");
            // p.PropA, p.PropB
            var memberValues =
                type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Select(t => new {Exp = Expression.MakeMemberAccess(p, t), Type = t.PropertyType})
                    .ToList();

            // p => (p.PropA == null ? 0 : p.PropA.GetHashCode()) ^ (p.PropB == null ? 0 : p.PropB.GetGetHashCode()) ^ 36
            var lambda =
                Expression.Lambda(
                    memberValues.Aggregate(
                        (Expression) Expression.Constant(36),
                        (t, current) =>
                            Expression.ExclusiveOr(
                                Expression.Condition(
                                    Expression.Equal(current.Exp, Expression.Default(current.Type)),
                                    Expression.Constant(0),
                                    Expression.Call(current.Exp, "GetHashCode", new Type[] {})), t)),
                    p);

            // ValueObject t
            var s = Expression.Parameter(typeof(ValueObject), "s");
            // lambda((type) t)
            var castingCall =
                Expression.Invoke(
                    lambda,
                    Expression.Convert(s, type));

            // t => lambda((type) t)
            var result =
                Expression.Lambda<Func<ValueObject, int>>(
                    castingCall,
                    s);

            return result.Compile();
        }
        private static Tuple<Func<ValueObject, ValueObject, bool>, Func<ValueObject, int>> BuildFunctionsTuple(Type type)
        {
            return
                Cache.GetOrAdd(
                    type,
                    t => new Tuple<Func<ValueObject, ValueObject, bool>, Func<ValueObject, int>>(
                        BuildEqualsFunction(t),
                        BuildHashCodeFunction(t)));
        }

        public bool Equals(ValueObject other)
        {
            if (other == null)
                return false;

            var type = GetType();
            if (type != other.GetType())
                return false;

            return BuildFunctionsTuple(type).Item1(this, other);
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as ValueObject);
        }
        public override int GetHashCode()
        {
            return BuildFunctionsTuple(GetType()).Item2(this);
        }
    }
}