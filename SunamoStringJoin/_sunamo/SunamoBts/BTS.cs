namespace SunamoStringJoin._sunamo.SunamoBts;

/// <summary>
/// Basic type system utilities.
/// </summary>
internal class BTS
{
    /// <summary>
    /// Optionally inverts a boolean value.
    /// </summary>
    /// <param name="value">The boolean value to potentially invert.</param>
    /// <param name="isInverting">Whether to invert the value.</param>
    internal static bool Invert(bool value, bool isInverting)
    {
        if (isInverting) return !value;
        return value;
    }
}
