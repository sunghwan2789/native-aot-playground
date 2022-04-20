using System.Runtime.InteropServices;

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
}
