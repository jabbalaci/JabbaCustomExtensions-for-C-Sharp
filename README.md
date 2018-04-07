Jabba's Custom Extensions for C#
================================

My own extensions for C#. Inspired by Python, Kotlin, etc.

Let's see some examples as an appetizer.

String methods
--------------

Capitalize a string

```cs
csi> "whatever".Capitalize();
"Whatever"
```

Reverse a string

```cs
csi> "abcd".ReverseStr();
"dcba"
```

String slicing, supporting negative indexing and step

```cs
csi> var s1 = "Fallout: New Vegas";

csi> s1.Slice(0, 4));
"Fall"
csi> s1.Slice(4, 7);
"out"
csi> s1.Slice(-3, s1.Length);
"gas"
csi> s1.Slice(-5, -1);
"Vega"


csi> var s2 = "python programming";

csi> s2.Slice(0, s1.Length, 2);
"pto rgamn"
csi> s2.Slice(0, 6, 2);
"pto"
```

String multiplication

```cs
csi> "x".Times(3);
"xxx"
```

Center a text

```cs
csi> "*".Center(10);
"    *     "
csi> "***".Center(10, '.');
"...***...."
```

String to int

```cs
csi> "42".ToInt();
42
```

String splitting

```cs
csi> var s4 = "   aa     bb    \t    cc        dd\n    ";
csi> s4.SplitAndRemoveEmptyEntries();
{"aa", "bb", "cc", "dd"}    // array of strings
```

List methods
------------

List slicing, supporting negative indexing and step

```cs
csi> var li1 = new List<char> {'a', 'b', 'c', 'd', 'e', 'f', 'g'};

csi> li1.Slice(2, 4);
{'c', 'd'}    // list of chars
csi> li1.Slice(2, -2));
{'c', 'd', 'e'}

csi> li1.Slice(0, 5, 2));
{'a', 'c', 'e'}
```

Pretty print
------------

Pretty print an array, a list, etc. Good for debugging.

```cs
csi> var seq3 = new List<int>() { 1, 5, 8 };
csi> Console.WriteLine(seq3);
System.Collections.Generic.List`1[System.Int32]    // ugly
csi> Console.WriteLine(seq3.Pretty());
[1, 5, 8]                                          // nice

csi> var seq5 = new List<string>() { "aa", "bb" };
csi> Console.WriteLine(seq5.Pretty());
["aa", "bb"]    // notice the quotes

csi> var seq6 = new List<string>() { 'a', 'b' };
csi> Console.WriteLine(seq6.Pretty());
['a', 'b']    // notice the apostrophes

csi> Console.WriteLine(Enumerable.Range(1, 5).Pretty());
[1, 2, 3, 4, 5]
```

Some Python built-in functions
------------------------------

Ranges

```cs
csi> Py.RangeExcl(10, 15).ToArray();
{10, 11, 12, 13, 14}    // array of ints, 15 excluded

csi> Py.RangeIncl(10, 15).ToArray();
{10, 11, 12, 13, 14, 15}    // array of ints, 15 included
```

Zip

```cs
csi> int[] numbers = { 1, 2, 3, 4 };
csi> string[] words = { "one", "two", "three" };
csi> char[] chars = { 'a', 'b', 'c', 'd', 'e', 'f' };

csi> Py.Zip(numbers, words);
[(1, "one"), (2, "two"), (3, "three")]    // an iterator over these tuples

csi> Py.Zip(numbers, words, chars);
[(1, "one", 'a'), (2, "two", 'b'), (3, "three", 'c')]    // an iterator over these tuples
```

----------

The list is not complete. See also the [source](JabbaCustomExtensions) and the [tests](JabbaCustomExtensionsTest).

How to use it?
--------------

```cs
using static System.Console;
using JabbaCustomExtensions;    // "import" it

namespace Hello
{
    class Program
    {
        public static void Main(string[] args)
        {
            WriteLine("hello".Capitalize());    // and then you can use it
        }
    }
}
```
