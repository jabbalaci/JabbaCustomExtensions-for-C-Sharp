using System;
using System.Linq;

namespace JabbaCustomExtensions
{
    /// <summary>
    /// My own string extensions.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Capitalize the string (like Python's s.capitalize()).
        /// Example: "hEllO".Capitalize() -> "Hello".
        /// </summary>
        public static string Capitalize(this string s)
        {
            if (s == null) throw new ArgumentNullException(nameof (s));    // if null
            // else
            if (s.Length == 0) return s;    // if empty string ("")
            // else
            return s.Substring(0, 1).ToUpper() + s.Substring(1).ToLower();
        }

        /// <summary>
        /// Reverse a string (like Python's s[::-1]).
        /// </summary>
        public static string ReverseStr(this string s)
        {
            if (s == null) throw new ArgumentNullException(nameof (s));
            // else
//            return string.Concat(s.Reverse());    // very slow
            var charArray = s.ToCharArray();    // much faster
            Array.Reverse(charArray);
            return new string(charArray);
        }

        /// <summary>
        /// Get the string slice between the two indexes (like Python).
        /// Inclusive for start index, exclusive for end index.
        /// </summary>
        public static string Slice(this string s, int start, int end)
        {
            if (s == null) throw new ArgumentNullException(nameof (s));
            // else

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
            var len = end - start;             // calculate length
            if (len < 0)
            {
                len = 0;
            }
            return s.Substring(start, len);    // return Substring of length
        }

        /// <summary>
        /// Get the string slice between the two indexes and keep only
        /// every step-th character (like Python).
        /// Inclusive for start index, exclusive for end index.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="start">Start position (inclusive).</param>
        /// <param name="end">End position (exclusive).</param>
        /// <param name="step">Keep every step-th character (and skip the others).</param>
        public static string Slice(this string input, int start, int end, int step)
        {
            if (step == 0)
            {
                throw new ArgumentOutOfRangeException(nameof (step));
            }
            if (step < 0)
            {
                throw new NotImplementedException("slice step must be >= 1");
            }
            var s = Slice(input, start, end);
            return string.Concat(s.Where((c, i) => i % step == 0));
        }

        /// <summary>
        /// Take the string n times and concatenate them together to a string.
        /// Like in Python: `"-" * 20`.
        /// </summary>
        public static string Times(this string s, int n)
        {
            if (s == null) throw new ArgumentNullException(nameof (s));
            // else
            return n < 0 ? string.Empty : string.Concat(Enumerable.Repeat(s, n));
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
            if (s == null) throw new ArgumentNullException(nameof (s));
            // else
            if (s.Length >= width)
            {
                return s;
            }
            // else
            var leftMarginWidth = (width - s.Length) / 2;
            var rightMarginWidth = width - s.Length - leftMarginWidth;
            // char.Times() is not used to avoid dependency
            return string.Format("{0}{1}{2}", new string(fillChar, leftMarginWidth),
                                              s,
                                              new string(fillChar, rightMarginWidth));
        }

        /// <summary>
        /// Convert the string to int (like Kotlin).
        /// </summary>
        public static int ToInt(this string s)
        {
            if (s == null) throw new ArgumentNullException(nameof (s));
            // else
            return  int.Parse(s);
        }

        /// <summary>
        /// Convert the string to float (like Kotlin).
        /// </summary>
        public static float ToFloat(this string s)
        {
            if (s == null) throw new ArgumentNullException(nameof (s));
            // else
            return  float.Parse(s);
        }

        /// <summary>
        /// Convert the string to double (like Kotlin).
        /// </summary>
        public static double ToDouble(this string s)
        {
            if (s == null) throw new ArgumentNullException(nameof (s));
            // else
            return  double.Parse(s);
        }

        /// <summary>
        /// Split the string by whitespaces and remove the empty entries (like Python's s.split()).
        /// </summary>
        /// <param name="s"></param>
        /// <returns>An array of strings containing non-empty parts.</returns>
        public static string[] SplitAndRemoveEmptyEntries(this string s)
        {
            if (s == null) throw new ArgumentNullException(nameof (s));
            // else
            return s.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
        }

    } // end class StringExtensions

}