using System.Web;
using xStudio.Common.Localization;
using Xunit;
using Xunit.Should;

namespace xStudio.UnitTests.Common.Localization
{
    public class TranslatedStringTests
    {
        [Fact]
        public void CanLocalizeWithPatternAndArgs()
        {
            var str = new TranslatedString("a{0}", 1);
            "a1".ShouldBe(str.ToString());
        }

        [Fact]
        public void CanConvertToHtmlString()
        {
            var str = new TranslatedString("blah");
            var html = str as IHtmlString;

            html.ShouldNotBeNull();
            "blah".ShouldBe(html.ToHtmlString());
        }

        [Fact]
        public void EqualsComparesContent()
        {
            var a = new TranslatedString("a");
            var b = new TranslatedString("a");
            a.ShouldBe(b);
        }

        [Fact]
        public void EqualsComparesOnlyWithLocalizedString()
        {
            var a = new TranslatedString("a");
            a.ShouldNotBe(null);
            a.ShouldNotBe(new object());
        }

        [Fact]
        public void SameContentGetSameHashcode()
        {
            var a = new TranslatedString("a");
            var b = new TranslatedString("a");
            a.GetHashCode().ShouldBe(b.GetHashCode());
        }

        [Fact]
        public void ItsAnImplicitString()
        {
            string str = new TranslatedString("blah");
            "blah".ShouldBe(str);
        }
    }
}
