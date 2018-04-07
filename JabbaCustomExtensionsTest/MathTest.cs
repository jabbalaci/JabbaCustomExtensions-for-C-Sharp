using System.Collections.Generic;
using JabbaCustomExtensions;
using Xunit;

namespace JabbaCustomExtensionsTest
{
    public class MathTest
    {
        [Fact]
        public void DivisorsTest()
        {
            Assert.Equal(new List<int> {1}, Euler.Divisors(1));
            Assert.Equal(new List<int> {1, 2, 4, 7, 14, 28}, Euler.Divisors(28));
            Assert.Equal(new List<int> {1, 2, 3, 5, 6, 10, 15, 30}, Euler.Divisors(30));
            Assert.Equal(new List<int> {1, 2, 17, 34}, Euler.Divisors(34));
        }

    } // end class MathTest

}
