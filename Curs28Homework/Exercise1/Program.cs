using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"\n\t [Main start] - thread id: {Thread.CurrentThread.ManagedThreadId}");

            Console.WriteLine($"\n\t Result: {new RunAsync().Run().GetAwaiter().GetResult()}");

            Console.WriteLine($"\n\t [Main end] - thread id: {Thread.CurrentThread.ManagedThreadId}");

            Console.ReadLine();
        }
    }
}
