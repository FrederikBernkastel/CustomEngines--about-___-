namespace FrederikaStudio.Core;

public static unsafe partial class SCU
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly record struct PointerArray<T>(IntPtr Handle);
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public readonly record struct PointerStringAnsi(IntPtr Handle);
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public readonly record struct PointerStringUnicode(IntPtr Handle);
    public static class CoreArray
    {
        public static ReadOnlySpan<T> PtrToArray<T>(PointerArray<T> handle, int count) => new(handle.Handle.ToPointer(), count);
        public static PointerArray<T> ArrayToPtr<T>(T[] array) where T: unmanaged
        {
            fixed (void* _array = array)
                return new(new(_array));
        }
    }
}