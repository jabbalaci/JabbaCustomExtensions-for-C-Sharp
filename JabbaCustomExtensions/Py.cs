using System;
using System.Collections.Generic;
using System.Linq;

namespace JabbaCustomExtensions
{
    /// <summary>
    /// Collecting features similar to the Python programming language.
    /// It contains implementations of Python built-in methods for instance.
    /// </summary>
    public static class Py
    {
        /// <summary>
        /// Make a range over [start..end) , where end is NOT included (exclusive).
        /// </summary>
        public static IEnumerable<int> RangeExcl(int start, int end) =>
            end <= start ? Enumerable.Empty<int>() : Enumerable.Range(start, end - start);

        /// <summary>
        /// Make a range over [start..end] , where end IS included (inclusive).
        /// </summary>
        public static IEnumerable<int> RangeIncl(int start, int end) =>
            RangeExcl(start, end + 1);

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

        // TODO: write just one Zip() method that can take 2 or more parameters
        //       and zips them up (like Python's zip()).

        /// <summary>
        /// Zip the first and second parameters (like Python's zip(seq1, seq2)).
        /// </summary>
        /// <typeparam name="TFirst">The first enumerable object.</typeparam>
        /// <typeparam name="TSecond">The second enumerable object.</typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>An iterator that aggregates elements from the two parameters.
        /// The elements are grouped in tuples.
        /// </returns>
        public static IEnumerable<(TFirst, TSecond)> Zip<TFirst, TSecond>(
            IEnumerable<TFirst> first,
            IEnumerable<TSecond> second)
        {
            return first.Zip(second, (a, b) => (a, b));
        }

        /// <summary>
        /// Zip the first, second and third parameters (like Python's zip(seq1, seq2, seq3)).
        /// </summary>
        /// <returns>An iterator that aggregates elements from the three parameters.
        /// The elements are grouped in tuples.
        /// </returns>
        public static IEnumerable<(TFirst, TSecond, TThird)> Zip<TFirst, TSecond, TThird>(
            IEnumerable<TFirst> first,
            IEnumerable<TSecond> second,
            IEnumerable<TThird> third)
        {
            return first.Zip(second, (a, b) => (a, b))
                .Zip(third, (t, c) => (t.Item1, t.Item2, c));
        }

        /// <summary>
        /// Sort an enumerable object (input) in ascending order.
        /// The input is not changed. The return value is a list.
        /// </summary>
        /// <param name="input">What you want to sort.</param>
        /// <typeparam name="T"></typeparam>
        /// <returns>Return a new list containing all items from the enumerable in ascending order.</returns>
        public static List<T> Sorted<T>(IEnumerable<T> input) =>
            input.OrderBy(x => x).ToList();

    } // end class Py

}