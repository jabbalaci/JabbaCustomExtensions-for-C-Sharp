using System;
using System.Collections.Generic;

namespace JabbaCustomExtensions
{
    /// <summary>
    /// Functions to solve mathematical problems.
    /// </summary>
    public static class Euler
    {
        /// <summary>
        /// Find the divisors of a whole number.
        /// For example: divisors of 6 are 1, 2, 3 and 6.
        /// </summary>
        /// <param name="n">The number whose divisors we want to get.</param>
        /// <returns>A list of integers containing the divisors.</returns>
        public static List<int> Divisors(int n)
        {
            var li = new List<int> { 1 };

            var half = n / 2;
            for (var i = 2; i < half + 1; ++i)
            {
                if (n % i == 0)
                {
                    li.Add(i);
                }
            }

            if (n > 1)
            {
                li.Add(n);
            }

            return li;
        }

        /// <summary>
        /// Decide whether a number is prime or not. This is a simple test and not efficient.
        /// For big numbers, use a more sophisticated algorithm.
        /// </summary>
        /// <param name="n"></param>
        /// <returns>True if the number is a prime; false if the number is not a prime.</returns>
        public static bool IsPrime(int n)
        {
            if (n < 2)
            {
                return false;
            }

            if (n == 2)
            {
                return true;
            }

            if (n % 2 == 0)
            {
                return false;
            }

            var i = 3;
            var max = Math.Sqrt(n) + 1;
            while (i <= max)
            {
                if (n % i == 0)
                {
                    return false;
                }

                i += 2;
            }

            return true;
        }

    } // end class Euler

}