using System.Runtime.InteropServices;
using Library.NativeTypes;

namespace Library;

public class Native
{
    [DllImport(nameof(Native))]
    public static extern int Add(int a, int b);

    [DllImport(nameof(Native))]
    public static extern int Subtract(int a, int b);

    [DllImport(nameof(Native))]
    public static extern int Sum(ArrayStruct array);

    [DllImport(nameof(Native))]
    public static extern ArrayStruct MinMax(ArrayStruct arrayStruct);
}
