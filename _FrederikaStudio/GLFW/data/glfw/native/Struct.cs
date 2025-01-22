namespace FrederikaStudio.GLFW;

public static class SNGLFW
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly record struct CursorGLFW(IntPtr Handle);
    [StructLayout(LayoutKind.Sequential)]
    public readonly record struct WindowGLFW(IntPtr Handle);
    [StructLayout(LayoutKind.Sequential)]
    public readonly record struct MonitorGLFW(IntPtr Handle);
    [StructLayout(LayoutKind.Sequential)]
    public readonly record struct ImageGLFW(int Width, int Height, SCU.PointerArray<byte> Pixels);
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct GammaRampGLFW
    {
        [MarshalAs(UnmanagedType.LPArray)]
        private readonly ushort[] Red, Green, Blue;
        private readonly uint Size;

        public GammaRampGLFW(IEnumerable<GammaRampRGB> rgb)
        {
            Size = (uint)rgb.Count();
            Red = rgb.Select(u => u.Red).ToArray();
            Green = rgb.Select(u => u.Green).ToArray();
            Blue = rgb.Select(u => u.Blue).ToArray();
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    public readonly record struct VidmodeGLFW(int Width, int Height, int RedBits, int GreenBits, int BlueBits, int RefreshRate);
    [StructLayout(LayoutKind.Sequential)]
    public readonly record struct GammaRampRGB(ushort Red, ushort Green, ushort Blue);
}