namespace SunamoStringJoin;

public partial class SHJoin
{
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

    public static string JoinNL(List<string> list, bool isRemovingLastNewline = false)
    {
        var newline = "\n";
        var result = JoinString(newline, list);
        if (isRemovingLastNewline)
            result = SH.TrimEnd(result, newline);
        return result;
    }

    public static string JoinString(object delimiter, List<string> list)
    {
        return Join(delimiter.ToString() ?? string.Empty, list);
    }

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

    public static string JoinWithoutEndTrimDelimiter(object delimiter, params string[] array)
    {
        return JoinWithoutTrim(delimiter, array);
    }

    public static string JoinSpace(List<string> list)
    {
        return JoinString(" ", list);
    }

    public static string JoinTimes(int times, string text)
    {
        var stringBuilder = new StringBuilder();
        for (var i = 0; i < times; i++)
            stringBuilder.Append(text);
        return stringBuilder.ToString();
    }

    public static string JoinWithoutTrim(object delimiter, IList list)
    {
        var stringBuilder = new StringBuilder();
        foreach (var item in list)
            stringBuilder.Append(item.ToString() + delimiter);
        return stringBuilder.ToString();
    }

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
