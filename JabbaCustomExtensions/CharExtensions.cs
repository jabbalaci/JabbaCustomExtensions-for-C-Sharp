namespace JabbaCustomExtensions
{
    /// <summary>
    /// My own char extensions.
    /// </summary>
    public static class CharExtensions
    {
        /// <summary>
        /// Take the character n times and concatenate them together to a string.
        /// Like in Python: `'-' * 20`.
        /// </summary>
        public static string Times(this char c, int n) =>
            n < 0 ? string.Empty : new string(c, n);

    } // end class CharExtensions

}