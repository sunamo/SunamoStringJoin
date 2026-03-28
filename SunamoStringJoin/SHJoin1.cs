namespace SunamoStringJoin;

public partial class SHJoin
{
    /// <summary>
    /// Joins list elements from a specified start index with a delimiter, trimming the last delimiter character.
    /// </summary>
    /// <param name="startIndex">The index to start joining from.</param>
    /// <param name="delimiter">The delimiter object.</param>
    /// <param name="list">The list of parts to join.</param>
    public static string JoinFromIndex(int startIndex, object delimiter, IList list)
    {
        var delimiterText = delimiter.ToString() ?? string.Empty;
        var stringBuilder = new StringBuilder();
        var index = 0;
        foreach (var item in list)
        {
            if (index >= startIndex)
                stringBuilder.Append(item + delimiterText);
            index++;
        }

        var result = stringBuilder.ToString();
        return result.Substring(0, result.Length - 1);
    }

    /// <summary>
    /// Joins a list of strings with newline characters.
    /// </summary>
    /// <param name="list">The list of strings to join.</param>
    /// <param name="isRemovingLastNewline">Whether to remove the trailing newline.</param>
    /// <returns>The joined string.</returns>
    public static string JoinNL(List<string> list, bool isRemovingLastNewline = false)
    {
        var newline = "\n";
        var result = JoinString(newline, list);
        if (isRemovingLastNewline)
            result = SH.TrimEnd(result, newline);
        return result;
    }

    /// <summary>
    /// Joins a list of strings with a delimiter. Wrapper for <see cref="Join(string, List{string})"/>.
    /// </summary>
    /// <param name="delimiter">The delimiter object.</param>
    /// <param name="list">The list of strings to join.</param>
    public static string JoinString(object delimiter, List<string> list)
    {
        return Join(delimiter.ToString() ?? string.Empty, list);
    }

    /// <summary>
    /// Joins list elements up to a specified end index (exclusive) with a delimiter.
    /// </summary>
    /// <param name="endIndex">The exclusive end index.</param>
    /// <param name="delimiter">The delimiter object.</param>
    /// <param name="list">The list of parts to join.</param>
    public static string JoinToIndex(int endIndex, object delimiter, IList list)
    {
        var delimiterText = delimiter.ToString() ?? string.Empty;
        var stringBuilder = new StringBuilder();
        var index = 0;
        foreach (var item in list)
        {
            if (index < endIndex)
                stringBuilder.Append(item + delimiterText);
            index++;
        }

        var result = stringBuilder.ToString();
        return result.Substring(0, result.Length - 1);
    }

    /// <summary>
    /// Joins string parts with a delimiter without trimming the end delimiter.
    /// </summary>
    /// <param name="delimiter">The delimiter object.</param>
    /// <param name="array">The string parts to join.</param>
    public static string JoinWithoutEndTrimDelimiter(object delimiter, params string[] array)
    {
        return JoinWithoutTrim(delimiter, array);
    }

    /// <summary>
    /// Joins a list of strings with a space delimiter.
    /// </summary>
    /// <param name="list">The list of strings to join.</param>
    public static string JoinSpace(List<string> list)
    {
        return JoinString(" ", list);
    }

    /// <summary>
    /// Repeats a text a specified number of times.
    /// </summary>
    /// <param name="times">The number of repetitions.</param>
    /// <param name="text">The text to repeat.</param>
    public static string JoinTimes(int times, string text)
    {
        var stringBuilder = new StringBuilder();
        for (var i = 0; i < times; i++)
            stringBuilder.Append(text);
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Joins list elements with a delimiter without trimming the end.
    /// </summary>
    /// <param name="delimiter">The delimiter object.</param>
    /// <param name="list">The list of parts to join.</param>
    public static string JoinWithoutTrim(object delimiter, IList list)
    {
        var stringBuilder = new StringBuilder();
        foreach (var item in list)
            stringBuilder.Append(item.ToString() + delimiter);
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Joins sentences, ensuring each ends with a period.
    /// </summary>
    /// <param name="isAddingAfterLast">Whether to keep the period after the last sentence.</param>
    /// <param name="array">The sentences to join.</param>
    public static string JoinSentences(bool isAddingAfterLast, params string[] array)
    {
        var stringBuilder = new StringBuilder();
        foreach (var item in array)
        {
            if (!string.IsNullOrEmpty(item))
            {
                stringBuilder.Append(item);
                if (!item.EndsWith('.'))
                    stringBuilder.Append('.');
            }
        }

        var result = stringBuilder.ToString();
        if (!isAddingAfterLast)
            result = SH.TrimEnd(result, ".");
        return result;
    }
}
