namespace FrederikaStudio.FrederikaEngine;

internal static class Extensions
{
    public static uint LengthInBytes<T>(this T[] values) where T : struct => (uint)(values.Length * Marshal.SizeOf<T>());
}
