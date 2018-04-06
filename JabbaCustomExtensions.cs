using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace JabbaCustomExtensions
{
    /// <summary>
    /// My own extension methods.
    /// Extension methods must be defined in a static class.
    /// </summary>
    public static class CustomExtensions
    {
        // This is the extension method.
        // The first parameter takes the "this" modifier
        // and specifies the type for which the method is defined.

        /// <summary>
        /// Capitalize the string (like Python).
        /// </summary>
        public static string Capitalize(this string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            // else
            return s.Substring(0, 1).ToUpper() + s.Substring(1).ToLower();
        }

        /// <summary>
        /// Reverse a string (like in Python: s[::-1]).
        /// </summary>
        public static string ReverseStr(this string s)
        {
            return new string(s.Reverse().ToArray());    // requires Linq
        }

        /// <summary>
        /// Get the string slice between the two indexes (like Python).
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

        /// <summary>
        /// Get the string slice between the two indexes and keep only
        /// every step-th character (like Python).
        /// Inclusive for start index, exclusive for end index.
        /// </summary>
        /// <param name="start">Start position (inclusive).</param>
        /// <param name="end">End position (exclusive).</param>
        /// <param name="step">Keep every step-th character (and skip the others).</param>
        public static string Slice(this string input, int start, int end, int step)
        {
            if (step == 0)
            {
                throw new ArgumentException("slice step cannot be zero");
            }
            if (step < 0)
            {
                throw new NotImplementedException("slice step must be >= 1");
            }
            var s = Slice(input, start, end);
            return string.Join("", s.Where((c, i) => i % step == 0));
        }

        /// <summary>
        /// Get the list slice between the two indexes (like Python).
        /// Inclusive for start index, exclusive for end index.
        /// </summary>
        /// <returns>A shallow copy of a list slice.</returns>
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

        /// <summary>
        /// Get the list slice between the two indexes and keep only
        /// every step-th character (like Python).
        /// Inclusive for start index, exclusive for end index.
        /// </summary>
        /// <param name="start">Start position (inclusive).</param>
        /// <param name="end">End position (exclusive).</param>
        /// <param name="step">Keep every step-th element (and skip the others).</param>
        /// <returns>A shallow copy of a list slice.</returns>
        public static List<T> Slice<T>(this List<T> input, int start, int end, int step)
        {
            if (step == 0)
            {
                throw new ArgumentException("slice step cannot be zero");
            }
            if (step < 0)
            {
                throw new NotImplementedException("slice step must be >= 1");
            }
            var li = Slice(input, start, end);
            return li.Where((c, i) => i % step == 0).ToList();
        }

        /// <summary>
        /// Take the character n times and concatenate them together to a string.
        /// Like in Python: `'-' * 20`.
        /// </summary>
        public static string Times(this char c, int n)
        {
            if (n < 0) return "";
            // else
            return new string(c, n);
        }

        /// <summary>
        /// Take the string n times and concatenate them together to a string.
        /// Like in Python: `"-" * 20`.
        /// </summary>
        public static string Times(this string s, int n)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < n; ++i)
            {
                sb.Append(s);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Center a string in a field of given width (like Python's str.center()).
        /// The string is never truncated.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="width">The returned string is at least this wide.</param>
        /// <param name="fillChar">Pad the string with this character (default: space).</param>
        /// <returns>The centered string.</returns>
        public static string Center(this string s, int width, char fillChar=' ')
        {
            var leftMarginWidth = (width - s.Length) / 2;
            var rightMarginWidth = width - s.Length - leftMarginWidth;
            return string.Format("{0}{1}{2}", fillChar.Times(leftMarginWidth),
                                              s,
                                              fillChar.Times(rightMarginWidth));
        }

        /// <summary>
        /// Convert the string to int (like Kotlin).
        /// </summary>
        public static int ToInt(this string s)
        {
            return int.Parse(s);
        }

        /// <summary>
        /// Split the string by whitespaces and remove the empty entries (like Python's s.split()).
        /// </summary>
        /// <param name="s"></param>
        /// <returns>An array of strings containing non-empty parts.</returns>
        public static string[] SplitAndRemoveEmptyEntries(this string s)
        {
            return s.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Pretty print an enumerable object, e.g. a list (like Python).
        /// Characters are between apostrophes, strings are between quotes.
        /// Example: ["aa", "bb"]. This output is more readable.
        /// </summary>
        /// <returns>A nicely formatted representation of the enumerable object, showing its elements.</returns>
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

    /// <summary>
    /// Features similar to the Python programming language.
    /// It contains implementations of Python built-in methods for instance.
    /// </summary>
    public static class Py
    {
        /// <summary>
        /// Make a range over [start..end) , where end is NOT included (exclusive).
        /// </summary>
        public static IEnumerable<int> RangeExcl(int start, int end)
        {
            if (end <= start) return Enumerable.Empty<int>();
            // else
            return Enumerable.Range(start, end - start);
        }

        /// <summary>
        /// Make a range over [start..end] , where end IS included (inclusive).
        /// </summary>
        public static IEnumerable<int> RangeIncl(int start, int end)
        {
            return RangeExcl(start, end + 1);
        }

        /// <summary>
        /// Read a line from the stdin (like Python's input()).
        /// </summary>
        /// <param name="prompt">Print this prompt first. Default: empty string.</param>
        /// <returns>The line provided by the user.</returns>
        public static string Input(string prompt="")
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        /// <summary>
        /// Zip the first and second parameters (like Python's zip(seq1, seq2)).
        /// </summary>
        /// <typeparam name="TFirst">The first enumerable object.</typeparam>
        /// <typeparam name="TSecond">The second enumerable object.</typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>An iterator that aggregates elements from the two parameters. The elements are grouped in tuples.</returns>
        public static IEnumerable<Tuple<TFirst, TSecond>> Zip<TFirst, TSecond>(
            IEnumerable<TFirst> first,
            IEnumerable<TSecond> second)
        {
            return first.Zip(second, Tuple.Create);
        }

    } // end class Py

}