using System.Collections.Generic;
using System.Linq;
using Xunit;
using JabbaCustomExtensions;

public class JabbaCustomExtensionsTest
{
    [Fact]
    public void Capitalize()
    {
        Assert.Equal("Whatever", "whatever".Capitalize());
        Assert.Equal("Whatever", "WHATEVER".Capitalize());
        Assert.Equal("", "".Capitalize());
        Assert.Equal("A", "a".Capitalize());
        Assert.Equal("One two", "one two".Capitalize());
    }

    [Fact]
    public void ToInt()
    {
        Assert.Equal(0, "0".ToInt());
        Assert.Equal(-1, "-1".ToInt());
        Assert.Equal(42, "42".ToInt());
        Assert.Equal(42, "42\n".ToInt());
        Assert.Equal(42, "    42".ToInt());
        Assert.Equal(42, "42    ".ToInt());
        Assert.Equal(42, "    42    ".ToInt());
    }

    [Fact]
    public void SplitAndRemoveEmptyEntries()
    {
        const string s1 = "aa bb cc dd";
        Assert.Equal(new[] {"aa", "bb", "cc", "dd"}, s1.SplitAndRemoveEmptyEntries());
        const string s2 = "aa";
        Assert.Equal(new[] {"aa"}, s2.SplitAndRemoveEmptyEntries());
        const string s3 = "";
        Assert.Equal(new string[] {}, s3.SplitAndRemoveEmptyEntries());
        const string s4 = "   aa     bb    \t    cc        dd\n    ";
        Assert.Equal(new[] {"aa", "bb", "cc", "dd"}, s4.SplitAndRemoveEmptyEntries());
    }

    [Fact]
    public void Pretty()
    {
        var seq1 = new List<int>();
        Assert.Equal("[]", seq1.Pretty());
        var seq2 = new List<int>(){1};
        Assert.Equal("[1]", seq2.Pretty());
        var seq3 = new List<int>(){1, 5, 8};
        Assert.Equal("[1, 5, 8]", seq3.Pretty());
        var seq4 = new List<string>(){"aa"};
        Assert.Equal("[\"aa\"]", seq4.Pretty());
        var seq5 = new List<string>(){"aa", "bb"};
        Assert.Equal("[\"aa\", \"bb\"]", seq5.Pretty());
        var seq6 = new List<char>(){'a'};
        Assert.Equal("['a']", seq6.Pretty());
        var seq7 = new List<char>(){'a', 'b'};
        Assert.Equal("['a', 'b']", seq7.Pretty());
        //
        Assert.Equal("[1]", Enumerable.Range(1, 1).Pretty());
        Assert.Equal("[1, 2, 3, 4, 5]", Enumerable.Range(1, 5).Pretty());
        Assert.Equal("[10, 11]", Enumerable.Range(10, 2).Pretty());
    }

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
        Assert.Equal(new int[] {10}, Py.RangeIncl(10, 10).ToArray());
        Assert.Equal(new int[] {}, Py.RangeIncl(10, 6).ToArray());
    }
}