namespace SunamoStringJoin;

/// <summary>
/// Represents the SH join type.
/// </summary>
public partial class SHJoin
{
    /// <summary>
    /// Join string.
    /// </summary>
    /// <param name="delimiter">The delimiter.</param>
    /// <param name="list">The list.</param>
    /// <returns>The join string result.</returns>
    public static string JoinString(string delimiter, List<string> list)
    {
        return Join(delimiter, list);
    }

    /// <summary>
    /// Join.
    /// </summary>
    /// <param name="delimiter">The delimiter.</param>
    /// <param name="list">The list.</param>
    /// <returns>The join result.</returns>
    public static string Join(string delimiter, List<string> list)
    {
        return string.Join(delimiter, list);
    }

    /// <summary>
    /// Join.
    /// </summary>
    /// <param name="delimiter">The delimiter.</param>
    /// <param name="array">The array.</param>
    /// <returns>The join result.</returns>
    public static string Join(object delimiter, params string[] array)
    {
        return string.Join(delimiter.ToString() ?? string.Empty, array);
    }

    /// <summary>
    /// Join array.
    /// </summary>
    /// <param name="delimiter">The delimiter.</param>
    /// <param name="array">The array.</param>
    /// <returns>The join array result.</returns>
    public static string JoinArray(object delimiter, params string[] array)
    {
        return Join(delimiter.ToString() ?? string.Empty, array);
    }

    /// <summary>
    /// Join NL sb.
    /// </summary>
    /// <param name="stringBuilder">The string builder.</param>
    /// <param name="list">The list.</param>
    /// <returns>The join NL sb result.</returns>
    public static string JoinNLSb(StringBuilder stringBuilder, List<string> list)
    {
        stringBuilder.Clear();
        foreach (var item in list)
            stringBuilder.AppendLine(item);
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Join chars.
    /// </summary>
    /// <param name="characters">The characters.</param>
    /// <returns>The join chars result.</returns>
    public static string JoinChars(params char[] characters)
    {
        var stringBuilder = new StringBuilder();
        foreach (var item in characters)
            stringBuilder.Append(item);
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Join comma.
    /// </summary>
    /// <param name="array">The array.</param>
    /// <returns>The join comma result.</returns>
    public static string JoinComma(params string[] array)
    {
        return Join(",", array);
    }

    /// <summary>
    /// Join dictionary.
    /// </summary>
    /// <param name="dictionary">The dictionary.</param>
    /// <param name="delimiterBetweenKeyAndValue">The delimiter between key and value.</param>
    /// <param name="delimiterAfter">The delimiter after.</param>
    /// <returns>The join dictionary result.</returns>
    public static string JoinDictionary(IDictionary<string, string> dictionary, string delimiterBetweenKeyAndValue, string delimiterAfter)
    {
        return JoinKeyValueCollection(dictionary.Keys.ToList(), dictionary.Values.ToList(), delimiterBetweenKeyAndValue, delimiterAfter);
    }

    /// <summary>
    /// Join dictionary.
    /// </summary>
    /// <param name="dictionary">The dictionary.</param>
    /// <param name="delimiter">The delimiter.</param>
    /// <returns>The join dictionary result.</returns>
    public static string JoinDictionary(Dictionary<string, string> dictionary, string delimiter)
    {
        var stringBuilder = new StringBuilder();
        foreach (var item in dictionary)
            stringBuilder.AppendLine(item.Key + delimiter + item.Value);
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Join key value collection.
    /// </summary>
    /// <param name="keys">The keys.</param>
    /// <param name="values">The values.</param>
    /// <param name="delimiterBetweenKeyAndValue">The delimiter between key and value.</param>
    /// <param name="delimiterAfter">The delimiter after.</param>
    /// <returns>The join key value collection result.</returns>
    public static string JoinKeyValueCollection(IList keys, IList values, string delimiterBetweenKeyAndValue, string delimiterAfter)
    {
        var stringBuilder = new StringBuilder();
        var index = 0;
        foreach (var item in keys)
            stringBuilder.Append(item + delimiterBetweenKeyAndValue + values[index++] + delimiterAfter);
        return SH.TrimEnd(stringBuilder.ToString(), delimiterAfter);
    }

    /// <summary>
    /// Join string params.
    /// </summary>
    /// <param name="delimiter">The delimiter.</param>
    /// <param name="array">The array.</param>
    /// <returns>The join string params result.</returns>
    public static string JoinStringParams(object delimiter, params string[] array)
    {
        return SHJoin.Join(delimiter, array);
    }

    /// <summary>
    /// Is number.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="mustContain">The must contain.</param>
    /// <param name="isInverting">The is inverting.</param>
    /// <returns>The is number result.</returns>
    public static bool IsNumber(string text, string mustContain, bool isInverting)
    {
        text = text.Replace(",", "");
        text = text.Replace(".", "");
        return BTS.Invert(long.TryParse(text, out _), isInverting);
    }

    /// <summary>
    /// Join more words.
    /// </summary>
    /// <param name="delimiter">The delimiter.</param>
    /// <param name="array">The array.</param>
    /// <returns>The join more words result.</returns>
    public static string JoinMoreWords(object delimiter, params string[] array)
    {
        array = CA.WrapWithIfFunc(IsNumber, true, "", "\"", array).ToArray();
        return Join(delimiter, array);
    }

    /// <summary>
    /// Join string except indexes.
    /// </summary>
    /// <param name="delimiter">The delimiter.</param>
    /// <param name="list">The list.</param>
    /// <param name="excludedIndexes">The excluded indexes.</param>
    /// <returns>The join string except indexes result.</returns>
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
