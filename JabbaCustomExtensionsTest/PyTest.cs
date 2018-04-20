using System;
using System.Collections.Generic;
using System.Linq;
using JabbaCustomExtensions;
using Xunit;

namespace JabbaCustomExtensionsTest
{
    /// <summary>
    /// Tests for the functions in the Py class.
    /// </summary>
    public class PyTest
    {
        [Fact]
        public void Py_RangeExcl()
        {
            Assert.Equal(new[] {10, 11, 12, 13, 14}, Py.RangeExcl(10, 15).ToArray());
            Assert.Equal(new[] {10}, Py.RangeExcl(10, 11).ToArray());
            Assert.Equal(new int[] {}, Py.RangeExcl(10, 10).ToArray());
            Assert.Equal(new int[] {}, Py.RangeExcl(10, 6).ToArray());
        }

        [Fact]
        public void Py_RangeIncl()
        {
            Assert.Equal(new[] {10, 11, 12, 13, 14, 15}, Py.RangeIncl(10, 15).ToArray());
            Assert.Equal(new[] {10, 11}, Py.RangeIncl(10, 11).ToArray());
            Assert.Equal(new[] {10}, Py.RangeIncl(10, 10).ToArray());
            Assert.Equal(new int[] {}, Py.RangeIncl(10, 6).ToArray());
        }

        [Fact]
        public void Py_Zip_with_2_parameters()
        {
            int[] numbers = { 1, 2, 3, 4 };
            string[] words = { "one", "two", "three" };
            Assert.Equal(numbers.Zip(words, (a, b) => (a, b)), Py.Zip(numbers, words));
        }

        [Fact]
        public void Py_Zip_with_3_parameters()
        {
            int[] numbers = { 1, 2, 3, 4 };
            string[] words = { "one", "two", "three" };
            char[] chars = { 'a', 'b', 'c', 'd', 'e', 'f' };

            var got = Py.Zip(numbers, words, chars).ToList();
            var expected = new List<(int, string, char)>
            {
                (1, "one", 'a'),
                (2, "two", 'b'),
                (3, "three", 'c')
            };
            Assert.Equal(expected, got);
        }

        [Fact]
        public void Py_Sorted()
        {
            var numbers = new[] {8, 3, 5, 1};
            Assert.Equal(new[] {1, 3, 5, 8}, Py.Sorted(numbers));
            Assert.Equal(new[] {8, 3, 5, 1}, numbers);
            Assert.Equal(new List<int>().GetType(), Py.Sorted(numbers).GetType());

            var words = new[] {"cc", "aa", "dd", "bb"};
            Assert.Equal(new[] {"aa", "bb", "cc", "dd"}, Py.Sorted(words));
            Assert.Equal(new[] {"cc", "aa", "dd", "bb"}, words);
            Assert.Equal(new List<string>().GetType(), Py.Sorted(words).GetType());
        }

    } // end class PyTest

}