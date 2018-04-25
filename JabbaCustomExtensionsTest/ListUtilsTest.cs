using System.Collections.Generic;
using static JabbaCustomExtensions.ListUtils;
using Xunit;

namespace JabbaCustomExtensionsTest
{
    /// <summary>
    /// Tests the list utilities.
    /// </summary>
    public class ListUtilsTest
    {
        [Fact]
        public void ShuffledTest()
        {
            var original = new List<int> {1, 2, 3, 4, 5};
            var shuffled = Shuffled(original);
            Assert.Equal(5, shuffled.Count);
            Assert.Equal(new List<int> {1, 2, 3, 4, 5}, original);
        }

    } // end class ListUtilsTest

}