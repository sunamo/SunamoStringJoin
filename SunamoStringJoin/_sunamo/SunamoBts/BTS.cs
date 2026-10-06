namespace SunamoStringJoin._sunamo.SunamoBts;

internal class BTS
{
    internal static bool Invert(bool value, bool isInverting)
    {
        if (isInverting) return !value;
        return value;
    }
}
