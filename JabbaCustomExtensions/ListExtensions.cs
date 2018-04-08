using System;
using System.Collections.Generic;
using System.Linq;

namespace JabbaCustomExtensions
{
    /// <summary>
    /// My own list extensions.
    /// </summary>
    public static class ListExtensions
    {
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
                throw new ArgumentOutOfRangeException("slice step cannot be zero");
            }
            if (step < 0)
            {
                throw new NotImplementedException("slice step must be >= 1");
            }
            var li = Slice(input, start, end);
            return li.Where((c, i) => i % step == 0).ToList();
        }

    } // end class ListExtensions

}