Jabba's Custom Extensions for C#
================================

My own extensions for C#. Inspired by Python, Kotlin, etc.

See the [test file](JabbaCustomExtensionsTest.cs) for examples.

Examples
--------

I put here some examples as an appetizer.

Capitalize a string

```cs
csi> "whatever".Capitalize()
"Whatever"
```

Reverse a string

```cs
csi> "abcd".ReverseStr()
"dcba"
```

String slicing, supporting negative indexing and step

```cs
csi> var s1 = "Fallout: New Vegas"
csi> s1.Slice(0, 4))
"Fall"
csi> s1.Slice(4, 7)
"out"
csi> s1.Slice(-3, s1.Length)
"gas"
csi> s1.Slice(-5, -1)
"Vega"

csi> var s2 = "python programming"
csi> s2.Slice(0, s1.Length, 2)
"pto rgamn"
csi> s2.Slice(0, 6, 2)
"pto"
```

String multiplication

```cs
csi> "x".Times(3)
"xxx"
```

Center a text

```cs
csi> "*".Center(10)
"    *     "
csi> "***".Center(10, '.')
"...***...."
```

String to int

```cs
csi> "42".ToInt()
42
```

String splitting

```cs
csi> var s4 = "   aa     bb    \t    cc        dd\n    ";
csi> s4.SplitAndRemoveEmptyEntries()
{"aa", "bb", "cc", "dd"}
```