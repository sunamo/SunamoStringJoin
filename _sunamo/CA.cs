namespace SunamoStringJoin._sunamo;

internal class CA
{
    internal static void InitFillWith(List<string> datas, int pocet, string initWith = "")
    {
        InitFillWith<string>(datas, pocet, initWith);
    }

    internal static void InitFillWith<T>(List<T> datas, int pocet, T initWith)
    {
        for (var i = 0; i < pocet; i++) datas.Add(initWith);
    }

    internal static void InitFillWith<T>(List<T> arr, int columns)
    {
        for (var i = 0; i < columns; i++) arr.Add(default);
    }


    internal static bool IsListStringWrappedInArray<T>(List<T> v2)
    {
        var first = v2.First().ToString();
        if (v2.Count == 1 && (first == "System.Collections.Generic.List`1[System.String]" ||
                              first == "System.Collections.Generic.List`1[System.Object]")) return true;
        return false;
    }

    internal static List<string> WrapWithIfFunc(Func<string, string, bool, bool> f, bool invert, string mustContains,
        string wrapWith, params string[] whereIsUsed2)
    {
        for (var i = 0; i < whereIsUsed2.Length; i++)
            if (f.Invoke(whereIsUsed2[i], mustContains, invert))
                whereIsUsed2[i] = wrapWith + whereIsUsed2[i] + wrapWith;
        return whereIsUsed2.ToList();
    }
}