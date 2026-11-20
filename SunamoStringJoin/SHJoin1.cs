namespace SunamoStringJoin;

public partial class SHJoin
{
    /// <summary>
    /// Join from index.
    /// </summary>
    /// <param name="startIndex">The start index.</param>
    /// <param name="delimiter">The delimiter.</param>
    /// <param name="list">The list.</param>
    /// <returns>The join from index result.</returns>
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
    /// Join NL.
    /// </summary>
    /// <param name="list">The list.</param>
    /// <param name="isRemovingLastNewline">The is removing last newline.</param>
    /// <returns>The join NL result.</returns>
    public static string JoinNL(List<string> list, bool isRemovingLastNewline = false)
    {
        var newline = "\n";
        var result = JoinString(newline, list);
        if (isRemovingLastNewline)
            result = SH.TrimEnd(result, newline);
        return result;
    }

    /// <summary>
    /// Join string.
    /// </summary>
    /// <param name="delimiter">The delimiter.</param>
    /// <param name="list">The list.</param>
    /// <returns>The join string result.</returns>
    public static string JoinString(object delimiter, List<string> list)
    {
        return Join(delimiter.ToString() ?? string.Empty, list);
    }

    /// <summary>
    /// Join to index.
    /// </summary>
    /// <param name="endIndex">The end index.</param>
    /// <param name="delimiter">The delimiter.</param>
    /// <param name="list">The list.</param>
    /// <returns>The join to index result.</returns>
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
    /// Join without end trim delimiter.
    /// </summary>
    /// <param name="delimiter">The delimiter.</param>
    /// <param name="array">The array.</param>
    /// <returns>The join without end trim delimiter result.</returns>
    public static string JoinWithoutEndTrimDelimiter(object delimiter, params string[] array)
    {
        return JoinWithoutTrim(delimiter, array);
    }

    /// <summary>
    /// Join space.
    /// </summary>
    /// <param name="list">The list.</param>
    /// <returns>The join space result.</returns>
    public static string JoinSpace(List<string> list)
    {
        return JoinString(" ", list);
    }

    /// <summary>
    /// Join times.
    /// </summary>
    /// <param name="times">The times.</param>
    /// <param name="text">The text.</param>
    /// <returns>The join times result.</returns>
    public static string JoinTimes(int times, string text)
    {
        var stringBuilder = new StringBuilder();
        for (var i = 0; i < times; i++)
            stringBuilder.Append(text);
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Join without trim.
    /// </summary>
    /// <param name="delimiter">The delimiter.</param>
    /// <param name="list">The list.</param>
    /// <returns>The join without trim result.</returns>
    public static string JoinWithoutTrim(object delimiter, IList list)
    {
        var stringBuilder = new StringBuilder();
        foreach (var item in list)
            stringBuilder.Append(item.ToString() + delimiter);
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Join sentences.
    /// </summary>
    /// <param name="isAddingAfterLast">The is adding after last.</param>
    /// <param name="array">The array.</param>
    /// <returns>The join sentences result.</returns>
    public static string JoinSentences(bool isAddingAfterLast, params string[] array)
    {
        var stringBuilder = new StringBuilder();
        foreach (var item in array)
        {
            if (!string.IsNullOrEmpty(item))
            {
                stringBuilder.Append(item);
                if (!item.EndsWith("."))
                    stringBuilder.Append('.');
            }
        }

        var result = stringBuilder.ToString();
        if (!isAddingAfterLast)
            result = SH.TrimEnd(result, ".");
        return result;
    }
}
