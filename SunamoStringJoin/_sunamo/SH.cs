namespace SunamoStringJoin._sunamo;

internal class SH
{
    internal static string TrimEnd(string text, string suffix)
    {
        while (text.EndsWith(suffix)) return text.Substring(0, text.Length - suffix.Length);
        return text;
    }
}
