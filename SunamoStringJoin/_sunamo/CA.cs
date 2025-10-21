// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoStringJoin._sunamo;

internal class CA
{





    internal static List<string> WrapWithIfFunc(Func<string, string, bool, bool> f, bool invert, string mustContains,
        string wrapWith, params string[] whereIsUsed2)
    {
        for (var i = 0; i < whereIsUsed2.Length; i++)
            if (f.Invoke(whereIsUsed2[i], mustContains, invert))
                whereIsUsed2[i] = wrapWith + whereIsUsed2[i] + wrapWith;
        return whereIsUsed2.ToList();
    }
}