using System.Collections.Generic;

namespace JabbaCustomExtensions
{
    /// <summary>
    /// List utilities.
    ///
    /// using static JabbaCustomExtensions.ListUtils;
    /// </summary>
    public static class ListUtils
    {
        /// <summary>
        /// Return with a shuffled (shallow) copy of the input list.
        /// The input list is not modified.
        /// </summary>
        /// <param name="li"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> Shuffled<T>(IEnumerable<T> li)
        {
            var shallowCopy = new List<T>(li);
            shallowCopy.Shuffle();
            return shallowCopy;
        }

    } // end class ListUtils

}