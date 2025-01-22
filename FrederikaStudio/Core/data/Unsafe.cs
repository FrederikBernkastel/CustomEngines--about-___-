namespace FrederikaStudio.UnsafeWork;

public static class ExtensionUnsafe
{
    public static PointerStruct<T> GetPointer<T>(this ref T value) where T : unmanaged => new(ref value);
    public static PointerArray<T> GetPointer<T>(this T[] array) where T : unmanaged => new(array);
    public static PointerArray<char> GetPointer(this string str) => new(str);
    public static unsafe string ToStringAnsii(this PointerArray<char> array_str) => 
        new((char*)array_str.Pointer.ToPointer());
    public static unsafe PointerArray<byte> Bytes(this string str, out int byteCount)
    {
        fixed (char* ptr = str)
        {
            byteCount = Encoding.UTF8.GetByteCount(ptr, str.Length);
            byte[] bytes = new byte[byteCount];
            PointerArray<byte> pointerArray = bytes.GetPointer();
            Encoding.UTF8.GetBytes(ptr, str.Length, (byte*)pointerArray.Pointer.ToPointer(), byteCount);
            return pointerArray;
        }
    }
    public static unsafe string GetString(this PointerArray<byte> str)
    {
        int characters = default;
        byte* ptr = (byte*)str.Pointer.ToPointer();
        while (ptr[characters] != 0) characters++;
        return GetString(str, characters);
    }
    public static unsafe string GetString(
        this PointerArray<byte> str, int byteCount) => 
        Encoding.UTF8.GetString((byte*)str.Pointer.ToPointer(), byteCount);
}
public readonly unsafe struct PointerStruct<T> where T : unmanaged
{
    private void* Handle { get; }
    internal PointerStruct(ref T ptr) => Handle = Unsafe.AsPointer(ref ptr);
    public IntPtr Pointer => new(Handle);
    public ref T This => ref Unsafe.AsRef<T>(Handle);
}
public readonly unsafe struct PointerArray<T> where T: unmanaged
{
    private void* Handle { get; }
    internal PointerArray(T[] array) { fixed (void* ptr = array) Handle = ptr; }
    internal PointerArray(string str) { fixed (void* ptr = str) Handle = ptr; }
    public IntPtr Pointer => new(Handle);
    public Span<T> ToArray(uint length) => new(Handle, (int)length);
}