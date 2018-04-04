using System.Collections.Generic;
using static JabbaCsLib.Euler;
using Xunit;

public class MathTest
{
    [Fact]
    public void DivisorsTest()
    {
        Assert.Equal(new List<int> {1}, Divisors(1));
        Assert.Equal(new List<int> {1, 2, 4, 7, 14, 28}, Divisors(28));
        Assert.Equal(new List<int> {1, 2, 3, 5, 6, 10, 15, 30}, Divisors(30));
        Assert.Equal(new List<int> {1, 2, 17, 34}, Divisors(34));
    }

}
