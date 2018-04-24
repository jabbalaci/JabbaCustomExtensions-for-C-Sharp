using System.Collections.Generic;
using System.Linq;
using JabbaCustomExtensions;
using Xunit;

namespace JabbaCustomExtensionsTest
{
    public class MathTest
    {
        [Fact]
        public void DivisorsTest()
        {
            Assert.Equal(new List<int> { 1 }, Euler.Divisors(1));
            Assert.Equal(new List<int> { 1, 2, 4, 7, 14, 28 }, Euler.Divisors(28));
            Assert.Equal(new List<int> { 1, 2, 3, 5, 6, 10, 15, 30 }, Euler.Divisors(30));
            Assert.Equal(new List<int> { 1, 2, 17, 34 }, Euler.Divisors(34));
        }

        [Fact]
        public void IsPrimeTest()
        {
            // expected
            var primesBelow100 = new List<int>
            {
                2,
                3,
                5,
                7,
                11,
                13,
                17,
                19,
                23,
                29,
                31,
                37,
                41,
                43,
                47,
                53,
                59,
                61,
                67,
                71,
                73,
                79,
                83,
                89,
                97,
            };
            var got = (from n in Py.RangeExcl(-10, 100) where Euler.IsPrime(n) select n).ToList();
            Assert.Equal(primesBelow100, got);
        }

    } // end class MathTest

}
