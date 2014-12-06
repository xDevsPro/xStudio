using xStudio.Common.Localization;
using Xunit;
using Xunit.Should;

namespace xStudio.UnitTests.Common.Localization
{
    public class LocalizationExtensionsTests
    {
        public Localizer T { get; set; }

        public LocalizationExtensionsTests()
        {
            T = NullLocalizer.Instance;
        }

        [Fact]
        public void PluralChooseRightTextToLocalize()
        {
            T.Plural("{0} cat", "{0} cats", 5).ToString().ShouldBe("5 cats");
            T.Plural("{0} cat", "{0} cats", 1).ToString().ShouldBe("1 cat");
        }
    }
}