namespace SunamoStringJoin;

/// <summary>
/// String helper methods for joining strings and collections with delimiters.
/// </summary>
public partial class SHJoin
{
    /// <summary>
    /// Joins a list of strings with a delimiter. Wrapper for <see cref="Join(string, List{string})"/>.
    /// </summary>
    /// <param name="delimiter">The delimiter to place between parts.</param>
    /// <param name="list">The list of strings to join.</param>
    public static string JoinString(string delimiter, List<string> list)
    {
        return Join(delimiter, list);
    }

    /// <summary>
    /// Joins a list of strings with a delimiter.
    /// </summary>
    /// <param name="delimiter">The delimiter to place between parts.</param>
    /// <param name="list">The list of strings to join.</param>
    /// <returns>The joined string.</returns>
    public static string Join(string delimiter, List<string> list)
    {
        return string.Join(delimiter, list);
    }

    /// <summary>
    /// Joins string parts with a delimiter object.
    /// </summary>
    /// <param name="delimiter">The delimiter object.</param>
    /// <param name="array">The string parts to join.</param>
    public static string Join(object delimiter, params string[] array)
    {
        return string.Join(delimiter.ToString() ?? string.Empty, array);
    }

    /// <summary>
    /// Joins string parts with a delimiter, validates correct argument order.
    /// </summary>
    /// <param name="delimiter">The delimiter object.</param>
    /// <param name="array">The string parts to join.</param>
    public static string JoinArray(object delimiter, params string[] array)
    {
        return Join(delimiter.ToString() ?? string.Empty, array);
    }

    /// <summary>
    /// Joins a list of strings with newlines using a StringBuilder.
    /// </summary>
    /// <param name="stringBuilder">The StringBuilder to use for joining.</param>
    /// <param name="list">The list of strings to join.</param>
    public static string JoinNLSb(StringBuilder stringBuilder, List<string> list)
    {
        stringBuilder.Clear();
        foreach (var item in list)
            stringBuilder.AppendLine(item);
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Joins characters into a single string.
    /// </summary>
    /// <param name="characters">The characters to join.</param>
    public static string JoinChars(params char[] characters)
    {
        var stringBuilder = new StringBuilder();
        foreach (var item in characters)
            stringBuilder.Append(item);
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Joins string arguments with a comma delimiter.
    /// </summary>
    /// <param name="array">The string arguments to join.</param>
    public static string JoinComma(params string[] array)
    {
        return Join(",", array);
    }

    /// <summary>
    /// Joins a dictionary into a string with specified delimiters between and after key-value pairs.
    /// </summary>
    /// <param name="dictionary">The dictionary to join.</param>
    /// <param name="delimiterBetweenKeyAndValue">The delimiter between each key and value.</param>
    /// <param name="delimiterAfter">The delimiter after each key-value pair.</param>
    public static string JoinDictionary(IDictionary<string, string> dictionary, string delimiterBetweenKeyAndValue, string delimiterAfter)
    {
        return JoinKeyValueCollection(dictionary.Keys.ToList(), dictionary.Values.ToList(), delimiterBetweenKeyAndValue, delimiterAfter);
    }

    /// <summary>
    /// Joins a dictionary into a string with each entry on a new line.
    /// </summary>
    /// <param name="dictionary">The dictionary to join.</param>
    /// <param name="delimiter">The delimiter between key and value on each line.</param>
    public static string JoinDictionary(Dictionary<string, string> dictionary, string delimiter)
    {
        var stringBuilder = new StringBuilder();
        foreach (var item in dictionary)
            stringBuilder.AppendLine(item.Key + delimiter + item.Value);
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Joins two parallel lists as key-value pairs with specified delimiters.
    /// </summary>
    /// <param name="keys">The list of keys.</param>
    /// <param name="values">The list of values.</param>
    /// <param name="delimiterBetweenKeyAndValue">The delimiter between each key and value.</param>
    /// <param name="delimiterAfter">The delimiter after each key-value pair.</param>
    public static string JoinKeyValueCollection(IList keys, IList values, string delimiterBetweenKeyAndValue, string delimiterAfter)
    {
        var stringBuilder = new StringBuilder();
        var index = 0;
        foreach (var item in keys)
            stringBuilder.Append(item + delimiterBetweenKeyAndValue + values[index++] + delimiterAfter);
        return SH.TrimEnd(stringBuilder.ToString(), delimiterAfter);
    }

    /// <summary>
    /// Joins string parts with a delimiter. Wrapper for <see cref="Join(object, string[])"/>.
    /// </summary>
    /// <param name="delimiter">The delimiter object.</param>
    /// <param name="array">The string parts to join.</param>
    public static string JoinStringParams(object delimiter, params string[] array)
    {
        return SHJoin.Join(delimiter, array);
    }

    /// <summary>
    /// Checks whether the input text represents a number.
    /// </summary>
    /// <param name="text">The text to check.</param>
    /// <param name="mustContain">Required content parameter used by delegate signature.</param>
    /// <param name="isInverting">Whether to invert the result.</param>
    public static bool IsNumber(string text, string mustContain, bool isInverting)
    {
        text = text.Replace(",", "");
        text = text.Replace(".", "");
        return BTS.Invert(long.TryParse(text, out _), isInverting);
    }

    /// <summary>
    /// Joins words, wrapping non-number elements with quotes.
    /// </summary>
    /// <param name="delimiter">The delimiter object.</param>
    /// <param name="array">The string parts to join.</param>
    public static string JoinMoreWords(object delimiter, params string[] array)
    {
        array = CA.WrapWithIfFunc(IsNumber, true, "", "\"", array).ToArray();
        return Join(delimiter, array);
    }

    /// <summary>
    /// Joins list elements with a delimiter, excluding elements at specified indexes.
    /// </summary>
    /// <param name="delimiter">The delimiter object.</param>
    /// <param name="list">The list of parts to join.</param>
    /// <param name="excludedIndexes">The indexes to exclude from joining.</param>
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
