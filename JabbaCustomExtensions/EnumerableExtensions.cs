using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JabbaCustomExtensions
{
    /// <summary>
    /// My own enumerable extensions.
    /// </summary>
    public static class EnumerableExtensions
    {
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

        /// <summary>
        /// Emulate Python's enumerate(seq).
        /// </summary>
        /// <param name="self"></param>
        /// <param name="start">Start value of the index. Default value: 0.</param>
        /// <typeparam name="T"></typeparam>
        /// <returns>Iterator for index, value of enumerable.</returns>
        public static IEnumerable<(int index, T item)> WithIndex<T>(this IEnumerable<T> self, int start=0)
            => self.Select((item, index) => (index + start, item));

    } // end class EnumerableExtensions

}