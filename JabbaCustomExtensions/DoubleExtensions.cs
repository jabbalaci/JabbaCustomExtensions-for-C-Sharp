using System;

namespace JabbaCustomExtensions
{
    /// <summary>
    /// My own double extensions. Overflow exception can occur
    /// if the double doesn't fit in an int.
    /// </summary>
    public static class DoubleExtensions
    {
        /// <summary>
        /// Convert a double to int.
        /// </summary>
        public static int ToInt(this double d) =>
            Convert.ToInt32(d);

    } // end class DoubleExtensions

}