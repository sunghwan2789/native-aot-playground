using System.Runtime.InteropServices;

namespace Library;

public class Native
{
    [DllImport(nameof(Native))]
    public static extern int Add(int a, int b);

    [DllImport(nameof(Native))]
    public static extern int Subtract(int a, int b);
}
