using System.Runtime.InteropServices;
using Library.NativeTypes;

namespace Library;

public partial class Native
{
    [LibraryImport(nameof(Native))]
    public static partial int Add(int a, int b);

    [LibraryImport(nameof(Native))]
    public static partial int Subtract(int a, int b);

    [LibraryImport(nameof(Native))]
    public static partial int Sum(ArrayStruct array);

    [LibraryImport(nameof(Native))]
    public static partial ArrayStruct MinMax(ArrayStruct arrayStruct);
}
