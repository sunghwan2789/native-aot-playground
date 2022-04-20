using System.Runtime.InteropServices;

namespace Library.NativeTypes;

public struct ArrayStruct
{
    public IntPtr Array;
    public int Length;

    public static implicit operator ArrayStruct(Array array)
    {
        return new ArrayStruct
        {
            Array = Marshal.UnsafeAddrOfPinnedArrayElement(array, 0),
            Length = array.Length,
        };
    }

    public Span<T> AsSpan<T>()
    {
        unsafe
        {
            return new Span<T>(Array.ToPointer(), Length);
        }
    }
}
