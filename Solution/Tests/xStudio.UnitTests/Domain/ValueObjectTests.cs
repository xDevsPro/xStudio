using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xStudio.Domain;
using Xunit;
using Xunit.Should;

namespace xStudio.UnitTests.Domain
{
    public class ValueObjectTests
    {
        class A : ValueObject
        {
            public int Number { get; set; }
        }
        class B : ValueObject
        {
            public int Number { get; set; }
        }
        class C : ValueObject
        {
            public int Number { get; set; }
            public string Text { get; set; }
            public DateTime Date { get; set; }
        }

        [Fact]
        public void ComparingEqualObjectsReturnsTrue()
        {
            ValueObject val =
                new C
                {
                    Number = 1,
                    Text = "Some TEXT",
                    Date = new DateTime(2014, 6, 12)
                };

            val.ShouldBe(
                new C
                {
                    Number = 1,
                    Text = "Some TEXT",
                    Date = new DateTime(2014, 6, 12)
                });
        }

        [Fact]
        public void ComparingDistinctObjectsReturnsFalse()
        {
            ValueObject val = new A { Number = 1 };
            val.ShouldNotBe(new A { Number = 2 });
        }

        [Fact]
        public void ComparingDifferentTypesWithSameValueReturnsFalse()
        {
            ValueObject val = new A { Number = 1 };
            val.ShouldNotBe(new B { Number = 1 });
        }

        [Fact]
        public void ComparingWithNullReturnsFalse()
        {
            ValueObject val = new A { Number = 1 };
            val.ShouldNotBe(null);
        }

        [Fact]
        public void ValueObjectReturnsTheSameHashForEqualObjects()
        {
            ValueObject val = 
                new C
                {
                    Number = 1,
                    Text = "Some TEXT",
                    Date = new DateTime(2014, 6, 12)
                };

            val.GetHashCode().ShouldBe(
                new C
                {
                    Number = 1,
                    Text = "Some TEXT",
                    Date = new DateTime(2014, 6, 12)
                }.GetHashCode());
        }
    }
}
