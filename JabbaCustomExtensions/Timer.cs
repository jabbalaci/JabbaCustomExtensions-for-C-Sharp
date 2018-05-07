using System;
using static System.Console;
using System.Diagnostics;

namespace JabbaCustomExtensions
{

    public class Timer
    {
        /// <summary>
        /// Wait for the given amount of milliseconds.
        /// </summary>
        /// <param name="millisecondsTimeout"></param>
        public static void Sleep(int millisecondsTimeout)
        {
            System.Threading.Thread.Sleep(millisecondsTimeout);
        }

        ///  <summary>
        ///  Measuring code execution time.
        ///  Taken from https://stackoverflow.com/a/37640207/232485
        ///
        ///  Usage:
        ///
        ///  using (var bench = new Timer.Benchmark($"Insert {n} records:"))
        ///  {
        ///      ... your code here
        ///  }
        ///
        ///  Output:
        ///
        ///  Insert 10 records: 00:00:00.0617594
        ///  </summary>
        public class Benchmark : IDisposable
        {
            private readonly Stopwatch _timer = new Stopwatch();
            private readonly string _benchmarkName;

            public Benchmark(string benchmarkName)
            {
                _benchmarkName = benchmarkName;
                _timer.Start();
            }

            public void Dispose()
            {
                _timer.Stop();
                WriteLine($"{_benchmarkName} {_timer.Elapsed}");
            }
        } // end class Benchmark

    } // end class Timer

}