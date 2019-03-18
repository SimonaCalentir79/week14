using System;
using System.Threading;
using System.Threading.Tasks;

namespace Exercise1
{
    public class RunAsync
    {
        public async Task<double> Run()
        {
            double result = 0;

            result = await ComputePi();

            return result;
        }

        private async Task<double> ComputePi()
        {
            Console.WriteLine($"\n\t [Function start] - thread id: {Thread.CurrentThread.ManagedThreadId}");
            var sum = 0.0;
            var step = 1e-9;

            for (var i = 0; i < 1000000000; i++)
            {
                var x = (i + 0.5) * step;
                sum = sum + 4.0 / (1.0 + x * x);
            }
            Console.WriteLine($"\n\t [Function end] - thread id: {Thread.CurrentThread.ManagedThreadId}");
            return sum * step;
        }
    }
}
