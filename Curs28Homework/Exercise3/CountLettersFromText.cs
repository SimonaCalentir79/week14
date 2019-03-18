using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Exercise3
{
    public class CountLettersFromText
    {
        public void Run()
        {
            this.CountLettersWithoutTPL();
            this.CountLettersWithTPL();
        }

        private string s = File.ReadAllText(@"Text.txt");

        private void CountLettersWithoutTPL()
        {
            char[] arrChar = s.ToCharArray();
            SortedDictionary<string, int> countOfChars = new SortedDictionary<string, int>();
            Stopwatch timer = new Stopwatch();

            for (int i = 0; i < arrChar.Length; i++)
            {
                timer.Restart();
                if (Char.IsLetter(arrChar[i]) && !countOfChars.Keys.Contains(arrChar[i].ToString().ToLower()))
                {
                    countOfChars.Add(arrChar[i].ToString().ToLower(), 1);
                }
                else if (countOfChars.Keys.Contains(arrChar[i].ToString().ToLower()))
                {
                    countOfChars[arrChar[i].ToString().ToLower()]++;
                }
                timer.Stop();
                //Console.WriteLine($" i: {i} - thread id: {Thread.CurrentThread.ManagedThreadId} ");
            }
            foreach (var item in countOfChars)
            {
                Console.WriteLine($"\t {item.Key} ~ {item.Value} time(s)");
            }
            Console.WriteLine($"\n\t Elapsed time: {timer.ElapsedMilliseconds} ms. on thread id: '{Thread.CurrentThread.ManagedThreadId}' (without TPL)");
        }

        public void CountLettersWithTPL()
        {
            char[] arrChar = s.ToCharArray();
            SortedDictionary<string, int> countOfChars = new SortedDictionary<string, int>();
            Stopwatch timer = new Stopwatch();

            Parallel.For(1, arrChar.Length, i =>
              {
                  timer.Restart();

                  lock (countOfChars)
                  {
                      if (Char.IsLetter(arrChar[i]) && !countOfChars.Keys.Contains(arrChar[i].ToString().ToLower()))
                      {
                          countOfChars.Add(arrChar[i].ToString().ToLower(), 1);
                      }
                      else if (countOfChars.Keys.Contains(arrChar[i].ToString().ToLower()))
                      {
                          countOfChars[arrChar[i].ToString().ToLower()]++;
                      }
                  }
                  
                  timer.Stop();
                  //Console.WriteLine($" i: {i} - thread id: {Thread.CurrentThread.ManagedThreadId} ");
              });
            foreach (var item in countOfChars)
            {
                Console.WriteLine($"\t {item.Key} ~ {item.Value} time(s)");
            }
            Console.WriteLine($"\n\t Elapsed time: {timer.ElapsedMilliseconds} ms. on thread id: '{Thread.CurrentThread.ManagedThreadId}' (with TPL)");
        }
    }
}
