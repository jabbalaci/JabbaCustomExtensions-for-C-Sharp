using JabbaCustomExtensions;
using Xunit;

namespace JabbaCustomExtensionsTest
{
    /// <summary>
    /// Tests for double extensions.
    /// </summary>
    public class DoubleExtensionsTest
    {
        [Fact]
        public void ToInt()
        {
            Assert.Equal(0, 0.0.ToInt());
            Assert.Equal(12, 12.0.ToInt());
            Assert.Equal(-12, -12.0.ToInt());
        }

    } // end class DoubleExtensionsTest

}