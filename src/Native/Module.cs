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
    public static unsafe int Sum(ArrayStruct arrayStruct)
    {
        var array = ArrayStructMarshaller.ConvertToManaged(arrayStruct);
        var span = array.AsSpan();
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
        var array = ArrayStructMarshaller.ConvertToManaged(arrayStruct);
        var span = array.AsSpan();
        var min = span[0];
        var max = span[0];
        foreach (var i in span[1..])
        {
            min = Math.Min(min, i);
            max = Math.Max(max, i);
        }

        var minMax = new[] { min, max };
        return ArrayStructMarshaller.ConvertToUnmanaged(minMax);
    }
}
