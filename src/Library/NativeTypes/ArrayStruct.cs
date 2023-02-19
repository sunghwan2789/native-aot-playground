using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Library.NativeTypes;

public struct ArrayStruct
{
    public nint Array;
    public int Length;
}

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

