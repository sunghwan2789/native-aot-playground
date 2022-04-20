using System.Runtime.InteropServices;
using Library.NativeTypes;

namespace Native;

public class Module
{
    [UnmanagedCallersOnly(EntryPoint = nameof(Add))]
    public static int Add(int a, int b)
    {
        return a + b;
    }

    [UnmanagedCallersOnly(EntryPoint = nameof(Subtract))]
    public static int Subtract(int a, int b)
    {
        return a - b;
    }

    [UnmanagedCallersOnly(EntryPoint = nameof(Sum))]
    public static int Sum(ArrayStruct arrayStruct)
    {
        var span = arrayStruct.AsSpan<int>();
        var total = 0;
        foreach (var i in span) {
            total += i;
        }
        return total;
    }
}
