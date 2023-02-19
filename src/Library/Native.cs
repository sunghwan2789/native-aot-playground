using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Library.NativeTypes;

namespace Library;

public partial class Native
{
    [LibraryImport(nameof(Native))]
    public static partial int Add(int a, int b);

    [LibraryImport(nameof(Native))]
    public static partial int Subtract(int a, int b);

    [LibraryImport(nameof(Native))]
    public static partial int Sum(
        [MarshalUsing(typeof(ArrayStructMarshaller))]
        int[] array);

    [LibraryImport(nameof(Native))]
    public static partial ArrayStruct MinMax(
        [MarshalUsing(typeof(ArrayStructMarshaller))]
        int[] array);
}
