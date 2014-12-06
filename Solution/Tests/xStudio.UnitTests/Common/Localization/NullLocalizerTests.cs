using System.Runtime.InteropServices;
using xStudio.Common.Localization;
using Xunit;
using Xunit.Should;

namespace xStudio.UnitTests.Common.Localization
{
    public class NullLocalizerTests
    {
        public Localizer T { get; set; }

        public NullLocalizerTests()
        {
            T = NullLocalizer.Instance;
        }

        [Fact]
        public void CanCreateLocalizer()
        {
            Assert.NotNull(T);
        }

        [Fact]
        public void LocalizerFromNullLocalizerCanLocalize()
        {
            T("msg {0}", 1).ShouldNotBeNull();
        }

        [Fact]
        public void LocalizedTextIsTheSameAsPassedText()
        {
            T("msg {0}", 1).ToString().ShouldBe("msg 1");
        }
    }
}