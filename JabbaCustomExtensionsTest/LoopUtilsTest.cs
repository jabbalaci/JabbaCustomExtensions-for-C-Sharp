using System.Collections.Generic;
using static JabbaCustomExtensions.LoopUtils;
using Xunit;

namespace JabbaCustomExtensionsTest
{
    /// <summary>
    /// Testing the loop utilities.
    /// </summary>
    public class LoopUtilsTest
    {
        [Fact]
        public void RepeatTest()
        {
            var li = new List<int>();
            Repeat(4, () =>
            {
                li.Add(1);
            });
            Assert.Equal(new List<int> { 1, 1, 1, 1 }, li);
        }

    } // end class LoopUtilsTest

}