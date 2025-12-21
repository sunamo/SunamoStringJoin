namespace SunamoStringJoin;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
public partial class SHJoin
{
    /// <summary>
    ///     Ořeže poslední znak - delimiter
    /// </summary>
    /// <param name = "dex"></param>
    /// <param name = "delimiter2"></param>
    /// <param name = "parts"></param>
    public static string JoinFromIndex(int dex, object delimiter2, IList parts)
    {
        var delimiter = delimiter2.ToString();
        var stringBuilder = new StringBuilder();
        var i = 0;
        foreach (var item in parts)
        {
            if (i >= dex)
                stringBuilder.Append(item + delimiter);
            i++;
        }

        var vr = stringBuilder.ToString();
        return vr.Substring(0, vr.Length - 1);
    //return SHSubstring.SubstringLength(vr, 0, vr.Length - 1);
    }

    /// <summary>
    ///     Usage: Exceptions.MoreCandidates
    /// </summary>
    /// <param name = "parts"></param>
    /// <param name = "removeLastNl"></param>
    /// <returns></returns>
    public static string JoinNL(List<string> parts, bool removeLastNl = false)
    {
        var nl = "\n";
        var result = JoinString(nl, parts);
        if (removeLastNl)
            result = SH.TrimEnd(result, nl);
        return result;
    }

    /// <summary>
    ///     Usage: Exceptions.MoreCandidates
    ///     Will be delete after final refactoring
    ///     Automaticky o�e�e posledn� A1
    /// </summary>
    /// ;
    /// <param name = "delimiter"></param>
    /// <param name = "parts"></param>
    public static string JoinString(object delimiter, List<string> parts)
    {
        // TODO: Delete after all app working, has here method Join with same arguments
        return Join(delimiter.ToString(), parts);
    }

    /// <summary>
    ///     A1 won't be included
    /// </summary>
    /// <param name = "dex"></param>
    /// <param name = "delimiter"></param>
    /// <param name = "parts"></param>
    public static string JoinToIndex(int dex, object delimiter2, IList parts)
    {
        var delimiter = delimiter2.ToString();
        var stringBuilder = new StringBuilder();
        var i = 0;
        foreach (var item in parts)
        {
            if (i < dex)
                stringBuilder.Append(item + delimiter);
            i++;
        }

        var vr = stringBuilder.ToString();
        return vr.Substring(0, vr.Length - 1);
    }

    public static string JoinWithoutEndTrimDelimiter(object name, params string[] parts)
    {
        // TODO: Delete after making all solutions working
        return JoinWithoutTrim(name, parts);
    }

    public static string JoinSpace(List<string> parts)
    {
        return JoinString(" ", parts);
    }

    public static string JoinTimes(int times, string dds)
    {
        // Working just for char
        //return new String(dds, times);
        var stringBuilder = new StringBuilder();
        for (var i = 0; i < times; i++)
            stringBuilder.Append(dds);
        return stringBuilder.ToString();
    }

    [Obsolete("Toto bych neměl, všude se má předává List")]
    private static string JoinNL(params string[] parts)
    {
        return JoinString(Environment.NewLine, parts.ToList());
    }

    public static string JoinWithoutTrim(object p, IList parts)
    {
        var stringBuilder = new StringBuilder();
        foreach (var item in parts)
            stringBuilder.Append(item.ToString() + p);
        return stringBuilder.ToString();
    }

    public static string JoinSentences(bool addAfterLast, params string[] pDescription)
    {
        var stringBuilder = new StringBuilder();
        foreach (var item in pDescription)
        {
            var temp = item.Trim();
            if (!string.IsNullOrEmpty(item))
            {
                stringBuilder.Append(item);
                if (!item.EndsWith("."))
                    stringBuilder.Append(".");
            }
        }

        var result = stringBuilder.ToString();
        if (!addAfterLast)
            result = SH.TrimEnd(result, ".");
        return result;
    }
}