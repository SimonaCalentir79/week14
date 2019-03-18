using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Exercise2
{
    public class TPLversion
    {
        public void Run()
        {
            this.ComputePiWithoutTPL();
            this.ComputePiWithTPL();
        }
        
        private double ComputePi()
        {
            double x, step = 1e-9, sum = 0.0;

            for (int i = 0; i < 1000000000; i++)
            {
                x = (i + 0.5) * step;
                sum = sum + 4.0 / (1.0 + x * x);
            }
            return sum*step;
        }

        private void ComputePiWithoutTPL()
        {
            double result;
            long totalTime = 0;
            Stopwatch timer = new Stopwatch();

            for (int j = 1; j < 6;j++)
            {
                timer.Restart();

                result = this.ComputePi();

                timer.Stop();
                totalTime += timer.ElapsedMilliseconds;
                Console.WriteLine($"\n\t {j} Elapsed time: {timer.ElapsedMilliseconds} ms. on thread id: '{Thread.CurrentThread.ManagedThreadId}' for result: {result} (without TPL)");
            }
            Console.WriteLine($"\n\t Total time for loop: {totalTime} ms., using one thread, sequentially.");
        }

        private void ComputePiWithTPL()
        {
            double result;
            Stopwatch timer = new Stopwatch();

            Parallel.For(1, 6, j =>
              {
                  timer.Restart();

                  result = ComputePi();

                  timer.Stop();
                  Console.WriteLine($"\n\t {j} Elapsed time: {timer.ElapsedMilliseconds} ms. on thread id: '{Thread.CurrentThread.ManagedThreadId}' for result: {result} (with TPL)");
              });
            Console.WriteLine($"\n\t Total time for loop {timer.ElapsedMilliseconds} ms., using parallel threads.");
        }
    }
}
