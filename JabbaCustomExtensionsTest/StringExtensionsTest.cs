﻿using System;
using JabbaCustomExtensions;
using Xunit;

namespace JabbaCustomExtensionsTest
{
    /// <summary>
    /// Tests for string extensions.
    /// </summary>
    public class StringExtensionsTest
    {
        [Fact]
        public void Capitalize()
        {
            string nullStr = null;
            Assert.Throws<ArgumentNullException>(() => nullStr.Capitalize());

            Assert.Equal("Whatever", "whatever".Capitalize());
            Assert.Equal("Whatever", "WHATEVER".Capitalize());
            Assert.Equal("", "".Capitalize());
            Assert.Equal("A", "a".Capitalize());
            Assert.Equal("One two", "one two".Capitalize());
        }

        [Fact]
        public void ReverseStr()
        {
            string nullStr = null;
            Assert.Throws<ArgumentNullException>(() => nullStr.ReverseStr());

            Assert.Equal("", "".ReverseStr());
            Assert.Equal("a", "a".ReverseStr());
            Assert.Equal("aa", "aa".ReverseStr());
            Assert.Equal("ba", "ab".ReverseStr());
            Assert.Equal("dcba", "abcd".ReverseStr());
            Assert.Equal("ólzsáL", "László".ReverseStr());
            Assert.Equal("b→a", "a→b".ReverseStr());
        }

        [Fact]
        public void Slice_string()
        {
            string nullStr = null;
            Assert.Throws<ArgumentNullException>(() => nullStr.Slice(0, 2));

            const string s1 = "Fallout: New Vegas";
            Assert.Equal("Fall", s1.Slice(0, 4));
            Assert.Equal("out", s1.Slice(4, 7));
            Assert.Equal("o", s1.Slice(4, 5));
            Assert.Equal("", s1.Slice(4, 4));
            Assert.Equal("out: New Vega", s1.Slice(4, 17));
            Assert.Equal("out: New Vegas", s1.Slice(4, 18));
            Assert.Equal("out: New Vegas", s1.Slice(4, 19));
            Assert.Equal("out: New Vegas", s1.Slice(4, 30));
            Assert.Equal("gas", s1.Slice(-3, s1.Length));
            Assert.Equal("Vegas", s1.Slice(-5, s1.Length));
            Assert.Equal("Vega", s1.Slice(-5, -1));
            Assert.Equal("", "".Slice(2, 4));
            Assert.Equal("", s1.Slice(100, 200));
            Assert.Equal("", s1.Slice(100, -2));
            Assert.Equal("as", s1.Slice(-2, 100));
            Assert.Equal("", s1.Slice(16, 16));
            Assert.Equal("", s1.Slice(17, 17));
            Assert.Equal("s", s1.Slice(17, 18));
            Assert.Equal("", s1.Slice(18, 18));
            Assert.Equal("", s1.Slice(19, 19));
            Assert.Equal("as", s1.Slice(16, 25));
            Assert.Equal(s1.Substring(7), s1.Slice(7, s1.Length));

            const string s2 = "batman";
            Assert.Equal("bat", s2.Slice(0, 3));
            Assert.Equal("man", s2.Slice(3, s2.Length));
            Assert.Equal("atm", s2.Slice(1, 4));
            Assert.Equal("man", s2.Slice(-3, s2.Length));
        }

        [Fact]
        public void Slice_string_with_step()
        {
            string nullStr = null;
            Assert.Throws<ArgumentNullException>(() => nullStr.Slice(0, 4, 2));

            const string s1 = "python programming";
            Assert.Equal(s1, s1.Slice(0, s1.Length, 1));
            Assert.Equal("pto rgamn", s1.Slice(0, s1.Length, 2));
            Assert.Equal("pto", s1.Slice(0, 6, 2));

            Assert.Throws<ArgumentOutOfRangeException>(() => s1.Slice(0, 6, 0));
            Assert.Throws<NotImplementedException>(() => s1.Slice(0, 6, -1));
            Assert.Throws<NotImplementedException>(() => s1.Slice(0, 6, -2));
        }

        [Fact]
        public void Times_string()
        {
            string nullStr = null;
            Assert.Throws<ArgumentNullException>(() => nullStr.Times(3));

            Assert.Equal("", "x".Times(0));
            Assert.Equal("x", "x".Times(1));
            Assert.Equal("xxx", "x".Times(3));
            Assert.Equal("", "x".Times(-2));
        }

        [Fact]
        public void Center()
        {
            string nullStr = null;
            Assert.Throws<ArgumentNullException>(() => nullStr.Center(10));

            Assert.Equal("    *     ", "*".Center(10));
            Assert.Equal("....*.....", "*".Center(10, '.'));
            Assert.Equal("....**....", "**".Center(10, '.'));
            Assert.Equal("...***....", "***".Center(10, '.'));
            Assert.Equal("**********", "**********".Center(10, '.'));
            Assert.Equal("***********", "***********".Center(10, '.'));
            Assert.Equal(".hello..", "hello".Center(8, '.'));
        }

        [Fact]
        public void ToInt()
        {
            string nullStr = null;
            Assert.Throws<ArgumentNullException>(() => nullStr.ToInt());

            Assert.Equal(0, "0".ToInt());
            Assert.Equal(-1, "-1".ToInt());
            Assert.Equal(42, "42".ToInt());
            Assert.Equal(42, "42\n".ToInt());
            Assert.Equal(42, "    42".ToInt());
            Assert.Equal(42, "42    ".ToInt());
            Assert.Equal(42, "    42    ".ToInt());
        }

        [Fact]
        public void ToFloat()
        {
            string nullStr = null;
            Assert.Throws<ArgumentNullException>(() => nullStr.ToFloat());

            Assert.Equal(0.1f, "0.1".ToFloat());
            Assert.Equal(-1.1f, "-1.1".ToFloat());
            Assert.Equal(42.1f, "42.1".ToFloat());
            Assert.Equal(42.1f, "42.1\n".ToFloat());
            Assert.Equal(42.1f, "    42.1".ToFloat());
            Assert.Equal(42.1f, "42.1    ".ToFloat());
            Assert.Equal(42.1f, "    42.1    ".ToFloat());
        }

        [Fact]
        public void ToDouble()
        {
            string nullStr = null;
            Assert.Throws<ArgumentNullException>(() => nullStr.ToDouble());

            Assert.Equal(0.1, "0.1".ToDouble());
            Assert.Equal(-1.1, "-1.1".ToDouble());
            Assert.Equal(42.1, "42.1".ToDouble());
            Assert.Equal(42.1, "42.1\n".ToDouble());
            Assert.Equal(42.1, "    42.1".ToDouble());
            Assert.Equal(42.1, "42.1    ".ToDouble());
            Assert.Equal(42.1, "    42.1    ".ToDouble());
        }

        [Fact]
        public void SplitAndRemoveEmptyEntries()
        {
            string nullStr = null;
            Assert.Throws<ArgumentNullException>(() => nullStr.SplitAndRemoveEmptyEntries());

            const string s1 = "aa bb cc dd";
            Assert.Equal(new[] { "aa", "bb", "cc", "dd" }, s1.SplitAndRemoveEmptyEntries());
            const string s2 = "aa";
            Assert.Equal(new[] { "aa" }, s2.SplitAndRemoveEmptyEntries());
            const string s3 = "";
            Assert.Equal(new string[] {}, s3.SplitAndRemoveEmptyEntries());
            const string s4 = "   aa     bb    \t    cc        dd\n    ";
            Assert.Equal(new[] {"aa", "bb", "cc", "dd"}, s4.SplitAndRemoveEmptyEntries());
        }

    } // end class StringExtensionsTest

}