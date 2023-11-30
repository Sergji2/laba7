using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        FunctionCache<int, string> cache = new FunctionCache<int, string>();

        Func<int, string> userFunction = key => $"Result for key {key}";

        string result1 = cache.Execute(userFunction, 1, TimeSpan.FromSeconds(5));
        Console.WriteLine("Result 1: " + result1);

        string result2 = cache.Execute(userFunction, 1, TimeSpan.FromSeconds(5));
        Console.WriteLine("Result 2: " + result2);

        System.Threading.Thread.Sleep(6000);

        string result3 = cache.Execute(userFunction, 1, TimeSpan.FromSeconds(5));
        Console.WriteLine("Result 3: " + result3);

    }
}
