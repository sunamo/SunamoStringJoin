namespace SunamoStringJoin._sunamo;

/// <summary>
/// String helper utilities.
/// </summary>
internal class SH
{
    /// <summary>
    /// Removes the specified suffix from the end of a string.
    /// </summary>
    /// <param name="text">The text to trim.</param>
    /// <param name="suffix">The suffix to remove.</param>
    internal static string TrimEnd(string text, string suffix)
    {
        while (text.EndsWith(suffix)) return text.Substring(0, text.Length - suffix.Length);
        return text;
    }
}
