namespace SunamoStringJoin._sunamo;

internal class CA
{
    internal static List<string> WrapWithIfFunc(Func<string, string, bool, bool> predicate, bool isInverting, string mustContain,
        string wrapWith, params string[] array)
    {
        for (var i = 0; i < array.Length; i++)
            if (predicate.Invoke(array[i], mustContain, isInverting))
                array[i] = wrapWith + array[i] + wrapWith;
        return array.ToList();
    }
}
