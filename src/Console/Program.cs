using System.Runtime.InteropServices;

Console.WriteLine($"1 + 2 = {Library.Native.Add(1, 2)}");
Console.WriteLine($"1 - 2 = {Library.Native.Subtract(1, 2)}");
Console.WriteLine($"sum from 1 to 5 = {Library.Native.Sum(new [] {1, 2, 3, 4, 5})}");
var minmax = Library.Native.MinMax(Enumerable.Range(-5, 11).ToArray()).AsSpan<int>();
Console.WriteLine($"min max from -5 to 5 = {minmax[0]} {minmax[1]}");

var hashset = new HashSet<int>() { 1, 2, 3, 4, 5 };
var hashsetOfInt = Marshal.AllocHGlobal(Marshal.SizeOf(hashset));
Marshal.StructureToPtr(hashset, hashsetOfInt, false);
Console.WriteLine(Library.Native.Contains(hashsetOfInt, 1));
Console.WriteLine(Library.Native.Contains(hashsetOfInt, 2));
Console.WriteLine(Library.Native.Contains(hashsetOfInt, 0));
Marshal.FreeHGlobal(hashsetOfInt);
