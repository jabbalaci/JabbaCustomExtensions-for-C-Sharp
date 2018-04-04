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
            if (end > s.Length)    // if the end value is too high
            {
                end = s.Length;
            }
            var len = end - start;             // Calculate length
            return s.Substring(start, len);    // Return Substring of length
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

        // string to int (like Kotlin)
        public static int ToInt(this string s)
        {
            return int.Parse(s);
        }

        // split by whitespaces and remove empty entries (like Python)
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
        public static string Input(string prompt = "")
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    } // end class Py

}