using System;

namespace JabbaCustomExtensions
{
    /// <summary>
    /// Making loops simpler.
    /// </summary>
    public static class LoopUtils
    {
        /// <summary>
        /// For example, you want to print a text 4 times. Now you can write it like this:
        ///
        /// Repeat(4, () =>
        /// {
        ///     WriteLine("hello");
        /// });
        ///
        /// You'll need this line:
        ///
        /// using static JabbaCustomExtensions.LoopUtils;
        ///
        /// </summary>
        /// <param name="times"></param>
        /// <param name="block"></param>
        public static void Repeat(int times, Action block)
        {
            for (var i = 0; i < times; ++i)
            {
                block();
            }
        }

    } // end class LoopUtils

}