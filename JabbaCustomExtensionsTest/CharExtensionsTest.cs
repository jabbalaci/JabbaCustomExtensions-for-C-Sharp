using JabbaCustomExtensions;
using Xunit;

namespace JabbaCustomExtensionsTest
{
    /// <summary>
    /// Tests for char extensions.
    /// </summary>
    public class CharExtensionsTest
    {
        [Fact]
        public void Times_char()
        {
            Assert.Equal("", 'x'.Times(0));
            Assert.Equal("x", 'x'.Times(1));
            Assert.Equal("xxx", 'x'.Times(3));
            Assert.Equal("", 'x'.Times(-2));
        }

    } // end class CharExtensionsTest

}