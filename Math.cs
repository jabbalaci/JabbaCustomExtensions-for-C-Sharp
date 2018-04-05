using System.Collections.Generic;

namespace JabbaCustomExtensions
{

    public static class Euler
    {
        public static List<int> Divisors(int n)
        {
            var li = new List<int> {1};

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
    }

}
