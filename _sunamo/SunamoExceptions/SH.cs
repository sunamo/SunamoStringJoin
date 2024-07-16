namespace SunamoStringJoin._sunamo.SunamoExceptions;

internal class SH
{
    internal static string TrimEnd(string name, string ext)
    {
        while (name.EndsWith(ext)) return name.Substring(0, name.Length - ext.Length);

        return name;
    }
}
