namespace SunamoStringJoin;

public partial class SHJoin
{
    public static string JoinString(string delimiter, List<string> list)
    {
        return Join(delimiter, list);
    }

    public static string Join(string delimiter, List<string> list)
    {
        return string.Join(delimiter, list);
    }

    public static string Join(object delimiter, params string[] array)
    {
        return string.Join(delimiter.ToString() ?? string.Empty, array);
    }

    public static string JoinArray(object delimiter, params string[] array)
    {
        return Join(delimiter.ToString() ?? string.Empty, array);
    }

    public static string JoinNLSb(StringBuilder stringBuilder, List<string> list)
    {
        stringBuilder.Clear();
        foreach (var item in list)
            stringBuilder.AppendLine(item);
        return stringBuilder.ToString();
    }

    public static string JoinChars(params char[] characters)
    {
        var stringBuilder = new StringBuilder();
        foreach (var item in characters)
            stringBuilder.Append(item);
        return stringBuilder.ToString();
    }

    public static string JoinComma(params string[] array)
    {
        return Join(",", array);
    }

    public static string JoinDictionary(IDictionary<string, string> dictionary, string delimiterBetweenKeyAndValue, string delimiterAfter)
    {
        return JoinKeyValueCollection(dictionary.Keys.ToList(), dictionary.Values.ToList(), delimiterBetweenKeyAndValue, delimiterAfter);
    }

    public static string JoinDictionary(Dictionary<string, string> dictionary, string delimiter)
    {
        var stringBuilder = new StringBuilder();
        foreach (var item in dictionary)
            stringBuilder.AppendLine(item.Key + delimiter + item.Value);
        return stringBuilder.ToString();
    }

    public static string JoinKeyValueCollection(IList keys, IList values, string delimiterBetweenKeyAndValue, string delimiterAfter)
    {
        var stringBuilder = new StringBuilder();
        var index = 0;
        foreach (var item in keys)
            stringBuilder.Append(item + delimiterBetweenKeyAndValue + values[index++] + delimiterAfter);
        return SH.TrimEnd(stringBuilder.ToString(), delimiterAfter);
    }

    public static string JoinStringParams(object delimiter, params string[] array)
    {
        return SHJoin.Join(delimiter, array);
    }

    public static bool IsNumber(string text, string mustContain, bool isInverting)
    {
        text = text.Replace(",", "");
        text = text.Replace(".", "");
        return BTS.Invert(long.TryParse(text, out _), isInverting);
    }

    public static string JoinMoreWords(object delimiter, params string[] array)
    {
        array = CA.WrapWithIfFunc(IsNumber, true, "", "\"", array).ToArray();
        return Join(delimiter, array);
    }

    public static string JoinStringExceptIndexes(object delimiter, IList list, params int[] excludedIndexes)
    {
        var delimiterText = delimiter.ToString() ?? string.Empty;
        var stringBuilder = new StringBuilder();
        var index = -1;
        foreach (string item in list)
        {
            index++;
            if (excludedIndexes.Any(excludedIndex => excludedIndex == index))
                continue;
            stringBuilder.Append(item + delimiterText);
        }

        var result = stringBuilder.ToString();
        var endIndex = result.Length - delimiterText.Length;
        if (endIndex > 0)
            return result.Substring(0, endIndex);
        return result;
    }
}
