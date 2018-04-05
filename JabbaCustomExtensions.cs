using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace JabbaCustomExtensions
{
    //Extension methods must be defined in a static class
    public static class CustomExtensions
    {
        // This is the extension method.
        // The first parameter takes the "this" modifier
        // and specifies the type for which the method is defined.

        // capitalize the string (like Python)
        public static string Capitalize(this string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            // else
            return s.Substring(0, 1).ToUpper() + s.Substring(1).ToLower();
        }

        // reverse a string (in Python: s[::-1])
        public static string ReverseStr(this string s)
        {
            return new string(s.Reverse().ToArray());    // requires Linq
        }

        /// <summary>
        /// Get the string slice between the two indexes.
        /// Inclusive for start index, exclusive for end index.
        /// </summary>
        public static string Slice(this string s, int start, int end)
        {
            // based on https://www.dotnetperls.com/string-slice
            if (start < 0)    // support negative indexing
            {
                start = s.Length + start;
            }
            if (end < 0)    // support negative indexing
            {
                end = s.Length + end;
            }
            if (start > s.Length)    // if the start value is too high
            {
                start = s.Length;
            }
            if (end > s.Length)    // if the end value is too high
            {
                end = s.Length;
            }
            var len = end - start;             // Calculate length
            if (len < 0)
            {
                len = 0;
            }
            return s.Substring(start, len);    // Return Substring of length
        }

        // slice support for lists (like Python)
        public static List<T> Slice<T>(this List<T> li, int start, int end)
        {
            if (start < 0)    // support negative indexing
            {
                start = li.Count + start;
            }
            if (end < 0)    // support negative indexing
            {
                end = li.Count + end;
            }
            if (start > li.Count)    // if the start value is too high
            {
                start = li.Count;
            }
            if (end > li.Count)    // if the end value is too high
            {
                end = li.Count;
            }
            var count = end - start;             // calculate count (number of elements)
            if (count < 0)
            {
                count = 0;
            }
            return li.GetRange(start, count);    // return a shallow copy of li of count elements
        }

        public static string Times(this char c, int n)
        {
            if (n < 0) return "";
            // else
            return new string(c, n);
        }

        public static string Times(this string s, int n)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < n; ++i)
            {
                sb.Append(s);
            }
            return sb.ToString();
        }

        // center a string in a field of given width (like Python's str.center())
        public static string Center(this string s, int width, char fillChar=' ')
        {
            var leftMarginWidth = (width - s.Length) / 2;
            var rightMarginWidth = width - s.Length - leftMarginWidth;
            return string.Format("{0}{1}{2}", fillChar.Times(leftMarginWidth),
                                              s,
                                              fillChar.Times(rightMarginWidth));
        }

        // string to int (like Kotlin)
        public static int ToInt(this string s)
        {
            return int.Parse(s);
        }

        // split by whitespaces and remove empty entries (like Python's s.split())
        public static string[] SplitAndRemoveEmptyEntries(this string s)
        {
            return s.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
        }

        // pretty print an enumerable object, e.g. a list (like Python)
        public static string Pretty<T>(this IEnumerable<T> li)
        {
            var sb = new StringBuilder("[");
            //
            var i = 0;
            foreach (var curr in li)
            {
                if (i > 0)
                {
                    sb.Append(", ");
                }

                if (curr is string)
                {
                    sb.Append('"');
                    sb.Append(curr);
                    sb.Append('"');
                }
                else if (curr is char)
                {
                    sb.Append("'");
                    sb.Append(curr);
                    sb.Append("'");
                }
                else
                {
                    sb.Append(curr);
                }

                ++i;
            }

            return sb.Append("]").ToString();
        }

    } // end class CustomExtensions


    public static class Py
    {
        // make a range over [start..end) , where end is NOT included (exclusive)
        public static IEnumerable<int> RangeExcl(int start, int end)
        {
            if (end <= start) return Enumerable.Empty<int>();
            // else
            return Enumerable.Range(start, end - start);
        }

        // make a range over [start..end] , where end IS included (inclusive)
        public static IEnumerable<int> RangeIncl(int start, int end)
        {
            return RangeExcl(start, end + 1);
        }

        // like Python's input()
        public static string Input(string prompt="")
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        // Like Python's zip(seq1, seq2). It returns an iterator over tuples.
        public static IEnumerable<Tuple<TFirst, TSecond>> Zip<TFirst, TSecond>(
            IEnumerable<TFirst> first,
            IEnumerable<TSecond> second)
        {
            return first.Zip(second, Tuple.Create);
        }

    } // end class Py

}