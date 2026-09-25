namespace SunamoStringJoin._sunamo;

/// <summary>
/// Collection array utilities.
/// </summary>
internal class CA
{
    /// <summary>
    /// Wraps array elements with a string if a predicate function returns true.
    /// </summary>
    /// <param name="predicate">The function to evaluate each element.</param>
    /// <param name="isInverting">Whether to invert the predicate result.</param>
    /// <param name="mustContain">The string that must be contained.</param>
    /// <param name="wrapWith">The string to wrap matching elements with.</param>
    /// <param name="array">The array of strings to process.</param>
    internal static List<string> WrapWithIfFunc(Func<string, string, bool, bool> predicate, bool isInverting, string mustContain,
        string wrapWith, params string[] array)
    {
        for (var i = 0; i < array.Length; i++)
            if (predicate.Invoke(array[i], mustContain, isInverting))
                array[i] = wrapWith + array[i] + wrapWith;
        return array.ToList();
    }
}
