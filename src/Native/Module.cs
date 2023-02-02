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
        foreach (var i in span)
        {
            total += i;
        }
        return total;
    }

    [UnmanagedCallersOnly(EntryPoint = nameof(MinMax))]
    public static ArrayStruct MinMax(ArrayStruct arrayStruct)
    {
        var span = arrayStruct.AsSpan<int>();
        var min = span[0];
        var max = span[0];
        foreach (var i in span[1..])
        {
            min = Math.Min(min, i);
            max = Math.Max(max, i);
        }

        return new [] { min, max };
    }

    [UnmanagedCallersOnly(EntryPoint = nameof(Contains))]
    public static bool Contains(nint hashsetOfInt, int value)
    {
        var hashset = Marshal.PtrToStructure<HashSet<int>>(hashsetOfInt);
        if (hashset is null)
        {
            Console.WriteLine("failed to convert");
            return false;
        }

        return hashset.Contains(value);
    }
}
