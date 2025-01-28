namespace SunamoStringJoin._sunamo;

internal class CA
{

    internal static void InitFillWith<T>(List<T> datas, int pocet, T initWith)
    {
        for (var i = 0; i < pocet; i++) datas.Add(initWith);
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