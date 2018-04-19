using System.Collections.Generic;
using System.Linq;
using JabbaCustomExtensions;
using Xunit;

namespace JabbaCustomExtensionsTest
{
    /// <summary>
    /// Tests for enumerable extensions.
    /// </summary>
    public class EnumerableExtensionsTest
    {
        [Fact]
        public void Pretty()
        {
            // ReSharper disable once CollectionNeverUpdated.Local
            var seq1 = new List<int>();
            Assert.Equal("[]", seq1.Pretty());

            var seq2 = new List<int>() { 1 };
            Assert.Equal("[1]", seq2.Pretty());

            var seq3 = new List<int>() { 1, 5, 8 };
            Assert.Equal("[1, 5, 8]", seq3.Pretty());

            var seq4 = new List<string>() { "aa" };
            Assert.Equal("[\"aa\"]", seq4.Pretty());

            var seq5 = new List<string>() { "aa", "bb" };
            Assert.Equal("[\"aa\", \"bb\"]", seq5.Pretty());

            var seq6 = new List<char>() { 'a' };
            Assert.Equal("['a']", seq6.Pretty());

            var seq7 = new List<char>() { 'a', 'b' };
            Assert.Equal("['a', 'b']", seq7.Pretty());
            //
            Assert.Equal("[1]", Enumerable.Range(1, 1).Pretty());
            Assert.Equal("[1, 2, 3, 4, 5]", Enumerable.Range(1, 5).Pretty());
            Assert.Equal("[10, 11]", Enumerable.Range(10, 2).Pretty());
        }

        [Fact]
        public void WithIndex()
        {
            var words = new List<string>() {"aa", "bb", "cc"};
            var wordsExpected = new List<(int, string)> { (0, "aa"), (1, "bb"), (2, "cc") };
            Assert.Equal(wordsExpected, words.WithIndex().ToList());

            var numbers = new List<int>() {24, 25, 26};
            var numbersExpected = new List<(int, int)> { (1, 24), (2, 25), (3, 26) };
            Assert.Equal(numbersExpected, numbers.WithIndex(start: 1).ToList());
        }

    } // end class EnumerableExtensionsTest

}