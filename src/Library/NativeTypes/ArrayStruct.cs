using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Library.NativeTypes;

public struct ArrayStruct
{
    public nint Array;
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

[CustomMarshaller(typeof(int[]), MarshalMode.ManagedToUnmanagedIn, typeof(ArrayStructMarshaller))]
[CustomMarshaller(typeof(int[]), MarshalMode.Default, typeof(ArrayStructMarshaller))]
public static unsafe class ArrayStructMarshaller
{
    public static ArrayStruct ConvertToUnmanaged(int[] managed)
    {
        return new ArrayStruct
        {
            Array = Marshal.UnsafeAddrOfPinnedArrayElement(managed, 0),
            Length = managed.Length,
        };
    }

    public static int[] ConvertToManaged(ArrayStruct unmanaged)
    {
        return new Span<int>(unmanaged.Array.ToPointer(), unmanaged.Length).ToArray();
    }
}

