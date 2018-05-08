using System;
using static System.Console;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using JabbaCustomExtensions;


namespace JabbaCustomExtensionsTimeIt
{
    class Program
    {
        /// <summary>
        /// Goal: measure the execution time of a function / method.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            const int repeat = 10_000_000;

            using (var bench = new Timer.Benchmark("Elapsed time:"))
            {
                var s = "sfershdfxjgfsduztr4e837465fvjdgf4dfguer658gdfjgtdsit43";

                for (var i = 0; i < repeat; ++i)
                {
                    var res = s.ReverseStr();
                }
            }
        }
    }
}