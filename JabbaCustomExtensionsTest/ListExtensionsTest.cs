using System;
using System.Collections.Generic;
using System.Linq;
using JabbaCustomExtensions;
using Xunit;

namespace JabbaCustomExtensionsTest
{
    /// <summary>
    /// Tests for list extensions.
    /// </summary>
    public class ListExtensionsTest
    {
        [Fact]
        public void Slice_list()
        {
            var li1 = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g' };
            Assert.Equal(new List<char> { 'c', 'd' }, li1.Slice(2, 4));
            Assert.Equal(new List<char> { 'b', 'c', 'd', 'e', 'f', 'g' }, li1.Slice(1, li1.Count));
            Assert.Equal(new List<char> { 'a', 'b', 'c' }, li1.Slice(0, 3));
            Assert.Equal(li1, li1.Slice(0, 4).Concat(li1.Slice(4, li1.Count)));
            Assert.Equal(li1, li1.Slice(0, 100));
            Assert.Equal(new List<char>(), li1.Slice(100, 200));
            Assert.Equal(new List<char>(), li1.Slice(100, -2));
            Assert.Equal(new List<char> { 'f', 'g' }, li1.Slice(-2, 100));

            Assert.Equal(new List<char> { 'g' }, li1.Slice(-1, li1.Count));
            Assert.Equal(new List<char> { 'f', 'g' }, li1.Slice(-2, li1.Count));
            Assert.Equal(new List<char> { 'a', 'b', 'c', 'd', 'e', 'f' }, li1.Slice(0, -1));

            Assert.Equal(new List<char> { 'c', 'd', 'e' }, li1.Slice(2, -2));
        }

        [Fact]
        public void Slice_list_with_step()
        {
            var li1 = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g' };
            Assert.Equal(li1, li1.Slice(0, li1.Count, 1));
            Assert.Equal(new List<char> { 'a', 'c', 'e', 'g' }, li1.Slice(0, li1.Count, 2));
            Assert.Equal(new List<char> { 'a', 'c', 'e' }, li1.Slice(0, 5, 2));

            Assert.Throws<ArgumentException>(() => li1.Slice(0, 6, 0));
            Assert.Throws<NotImplementedException>(() => li1.Slice(0, 6, -1));
            Assert.Throws<NotImplementedException>(() => li1.Slice(0, 6, -2));
        }

    } // end ListExtensionsTest

}