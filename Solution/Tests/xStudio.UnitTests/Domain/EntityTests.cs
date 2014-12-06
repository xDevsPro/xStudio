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
    public class EntityTests
    {
        class A : Entity
        {
            public A(int id)
            {
                Id = id;
            }
        }
        class B : Entity
        {
            public B(int id)
            {
                Id = id;
            }
        }
        class C : Entity
        {
            public C(int id)
            {
                Id = id;
            }
            public string Text { get; set; }
            public DateTime Date { get; set; }
        }

        [Fact]
        public void ComparingEqualIdsReturnsTrue()
        {
            Entity val =
                new C(1)
                {
                    Text = "Some TEXT",
                    Date = new DateTime(2014, 6, 12)
                };

            val.ShouldBe(
                new C(1)
                {
                    Text = "Some TEXT",
                    Date = new DateTime(2014, 6, 12)
                });
        }

        [Fact]
        public void ComparingDistinctIdsReturnsFalse()
        {
            Entity val = new A(1);
            val.ShouldNotBe(new A(2));
        }

        [Fact]
        public void ComparingDifferentTypesWithIdReturnsFalse()
        {
            Entity val = new A(1);
            val.ShouldNotBe(new B(1));
        }

        [Fact]
        public void ComparingWithNullReturnsFalse()
        {
            Entity val = new A(1);
            val.ShouldNotBe(null);
        }

        [Fact]
        public void EntityReturnsTheSameHashForEqualObjects()
        {
            Entity val = 
                new C(1)
                {
                    Text = "Some TEXT",
                    Date = new DateTime(2014, 6, 12)
                };

            val.GetHashCode().ShouldBe(
                new C(1)
                {
                    Text = "Some TEXT",
                    Date = new DateTime(2014, 6, 12)
                }.GetHashCode());
        }
    }
}
