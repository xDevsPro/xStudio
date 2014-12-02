using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace xStudio.UnitTests
{
    // ReSharper disable TestClassNameSuffixWarning
    public class SanityCheck
    // ReSharper restore TestClassNameSuffixWarning
    {
        [Fact]
        public void Pass()
        {
            Assert.True(true);
        }
    }
}
