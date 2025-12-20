// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoStringJoin;
public partial class SHJoin
{
    private static Type type = typeof(SHJoin);
    /// <summary>
    ///     Usage: Exceptions.MoreCandidates
    ///     Will be delete after final refactoring
    ///     Automaticky o�e�e posledn� A1
    /// </summary>
    /// <param name = "delimiter"></param>
    /// <param name = "parts"></param>
     //[ObjectObsolete]
    public static string JoinString(string delimiter, List<string> parts)
    {
        // TODO: Delete after all app working, has here method Join with same arguments
        return Join(delimiter, parts);
    }

    ///// <summary>
    /////     Start at 0
    /////     Usage: MethodOfOccuredFromStackTrace
    ///// </summary>
    ///// <param name="input"></param>
    ///// <param name="lenght"></param>
    ///// <returns></returns>
    //public static string SubstringIfAvailable(string input, int lenght)
    //{
    //    return input.Length > lenght ? input.Substring(0, lenght) : input;
    //}
    ////
    ///// <summary>
    /////     Usage: Exceptions.TypeAndMethodName
    /////     Remove with A2
    ///// </summary>
    ///// <param name="t"></param>
    ///// <param name="ch"></param>
    //public static string RemoveAfterFirst(string temp, char ch)
    //{
    //    int dex = temp.IndexOf(ch);
    //    return dex == -1 || dex == temp.Length - 1 ? temp : temp.Substring(0, dex);
    //}
    ///// <summary>
    /////     Usage: Exc.MethodOfOccuredFromStackTrace
    ///// </summary>
    ///// <param name="item"></param>
    ///// <returns></returns>
    //public static string FirstLine(string item)
    //{
    //    List<string> lines = GetLines(item);
    //    return lines.Count == 0 ? string.Empty : lines[0];
    //}
    ///// <summary>
    /////     Usage: Exceptions.TypeAndMethodName
    ///// </summary>
    ///// <param name="v"></param>
    ///// <param name="s"></param>
    ///// <returns></returns>
    //public static string TrimStart(string v, string text)
    //{
    //    while (v.StartsWith(text))
    //    {
    //        v = v.Substring(text.Length);
    //    }
    //    return v;
    //}
    /// <summary>
    ///     Usage: Exceptions.TypeAndMethodName
    /// </summary>
    /// <param name = "dot"></param>
    /// <param name = "p"></param>
    /// <returns></returns>
    public static string Join(string dot, List<string> p)
    {
        return string.Join(dot, p);
    }

    /// <summary>
    ///     Can be use also with IList
    ///     <string>
    ///         - will take first element of A2
    ///         Automaticky o�e�e posledn� znad A1
    ///         Pokud m� inty v A2, pou�ij metodu JoinMakeUpTo2NumbersToZero
    /// </summary>
    /// <param name = "delimiter"></param>
    /// <param name = "parts"></param>
     ////[ObjectParamsObsolete]
    public static string Join(object delimiter, params string[] parts)
    {
        return string.Join(delimiter.ToString(), parts);
    //if (parts.Length == 0)
    //{
    //    // házelo mi to chybu, takže vrátím prostě SE
    //    //throw new Exception("Not passed any parts, only delimiter: " + delimiter);
    //    return "";
    //}
    //IList enu = parts.ToList();
    //if (delimiter is IList enumerable && delimiter.GetType() != Types.tString)
    //{
    //    IList ie = enumerable;
    //    if (ie.Count > 1 && enu.Count == 1)
    //    {
    //        throw new Exception(Translate.FromKey(XlfKeys.ProbablyWasCalledWithSwithechDelimiterAndParts));
    //    }
    //}
    //// JoinString point to Join with implementation
    //return JoinString(delimiter.ToString(), enu);
    }

    /// <summary>
    ///     Usage: Exceptions.StringContainsUnallowedSubstrings
    ///     Automaticky o�e�e posledn� znad A1
    ///     Pokud m� inty v A2, pou�ij metodu JoinMakeUpTo2NumbersToZero
    /// </summary>
    /// <param name = "delimiter"></param>
    /// <param name = "parts"></param>
    public static string JoinArray(object delimiter, params string[] enu)
    {
        //IList enu = new List<string>IEnumerable2(parts);
        if (delimiter is IList /*enumerable*/ && delimiter.GetType() != typeof(string))
        {
            IList ie = enu /*merable*/;
            if (ie.Count > 1 && enu.Length == 1)
                throw new Exception(Translate.FromKey(XlfKeys.ProbablyWasCalledWithSwithechDelimiterAndParts));
        }

        // JoinString point to Join with implementation
        return Join(delimiter.ToString(), enu);
    }

    public static string JoinNLSb(StringBuilder stringBuilder, List<string> list)
    {
        stringBuilder.Clear();
        foreach (var item in list)
            stringBuilder.AppendLine(item);
        return stringBuilder.ToString();
    }

    public static string JoinChars(params char[] ch)
    {
        var stringBuilder = new StringBuilder();
        foreach (var item in ch)
            stringBuilder.Append(item);
        return stringBuilder.ToString();
    }

    public static string JoinComma(params string[] args)
    {
        return Join(",", args);
    }

    public static string JoinDictionary(IDictionary<string, string> dict, string delimiterBetweenKeyAndValue, string delimAfter)
    {
        return JoinKeyValueCollection(dict.Keys.ToList(), dict.Values.ToList(), delimiterBetweenKeyAndValue, delimAfter);
    }

    public static string JoinDictionary(Dictionary<string, string> dictionary, string delimiter)
    {
        var stringBuilder = new StringBuilder();
        foreach (var item in dictionary)
            stringBuilder.AppendLine(item.Key + delimiter + item.Value);
        return stringBuilder.ToString();
    }

    public static string JoinKeyValueCollection(IList v1, IList v2, string delimiterBetweenKeyAndValue, string delimAfter)
    {
        var stringBuilder = new StringBuilder();
        var v2List = new List<object>(v2.Count);
        foreach (var item in v2)
            v2List.Add(item);
        var i = 0;
        foreach (var item in v1)
            stringBuilder.Append(item + delimiterBetweenKeyAndValue + v2List[i++] + delimAfter);
        return SH.TrimEnd(stringBuilder.ToString(), delimAfter);
    }

    //public static string JoinStringParams(string name, params string[] labels) { return null; }
    //public static string JoinStringParams(object delimiter, params string[] parts) { return null; }
    //public static string JoinPairs(params string[] args){return null;}
    //public static string JoinString(object delimiter, IList parts){return null;}
    //public static string Join(IList parts, object delimiter){return null;}
    //public static string JoinIList(object delimiter, IList parts){return null;}
    //public static string Join(char p, IList vsechnyFotkyVAlbu){return null;}
    //public static string Join(char p, int[] vsechnyFotkyVAlbu){return null;}
    //public static string Join(char name, params string[] labels){return null;}
    //public static string Join(List<string> labels, char name){return null;}
    //public static string JoinNL(IList p){return null;}
    //public static string JoinNL(params string[] p){return null;}
    //public static string JoinSpace(IList<string> nazev){return null;}
    //public static string JoinString(string name, IList labels){return null;}
    //public static string JoinStringExceptIndexes(string name, IList labels, params int[] v2){return null;}
    //public static string JoinMoreWords(char v, params string[] fields){return null;}
    //public static string JoinWithoutTrim(string p, IList ownedCatsLI){return null;}
    //public static string JoinIList(char name, IList labels){return null;}
    //public static string JoinWithoutEndTrimDelimiter(string name, params string[] labels){return null;}
    //public static string JoinFromIndex(int p, char delimiter, IList<string> tokeny){return null;}
    //public static string JoinFromIndex(int dex, string delimiter, IList<string> parts){return null;}
    //public static string JoinToIndex(int dex, string delimiter, IList<string> parts){return null;}
    //public static string JoinMakeUpTo2NumbersToZero(char p, params int[] args){return null;}
    //public static string JoinDictionary(Dictionary<string, string> dictionary, string v){return null;}
    /* Result of refactoring Join methods:
     * params have only two:
     * Join
     * JoinString
     */
    ////[ObjectParamsObsolete]
    public static string JoinStringParams(object delimiter, params string[] parts)
    {
        // TODO: Delete after all app working, has here method Join with same arguments
        return SHJoin.Join(delimiter, (parts));
    }

    public static bool IsNumber(string input, string value, bool invert)
    {
        input = input.Replace(",", "");
        input = input.Replace(".", "");
        long list = 0;
        return BTS.Invert(long.TryParse(input, out list), invert);
    }

    // refaktorovat to tady, nemuzu zavolat params z IEnum . Teprve ve working method zkontroluji co je za typ a pripadne pretypuji
    /// <summary>
    ///     If element will be number, wont wrap with qm.
    /// </summary>
    /// <param name = "delimiter"></param>
    /// <param name = "parts"></param>
    public static string JoinMoreWords(object delimiter, params string[] parts)
    {
        parts = CA.WrapWithIfFunc(IsNumber, true, "", "\"", parts).ToArray();
        return Join(delimiter, parts);
    }

    public static string JoinStringExceptIndexes(object delimiter, IList parts, params int[] v2)
    {
        var text = delimiter.ToString();
        var stringBuilder = new StringBuilder();
        var i = -1;
        foreach (string item in parts)
        {
            i++;
            if (v2.Any(data => data == i))
                continue;
            stringBuilder.Append(item + text);
        }

        var data = stringBuilder.ToString();
        //return data.Remove(data.Length - (name.Length - 1), name.Length);
        var to = data.Length - text.Length;
        if (to > 0)
            return data.Substring(0, to);
        return data;
    //return data;
    }
}