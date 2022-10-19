using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace SyncAsyncCompareApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> WorkList = Enumerable.Range(0, 10).ToList();
            Stopwatch stopWatch = new Stopwatch();

            Console.WriteLine("--- Standard Foreach -------");
            stopWatch.Start();
            foreach (var i in WorkList)
            {
                Thread.Sleep(1000);
                Console.WriteLine(@"{0}. Work Start , Thread = {1}", i, Thread.CurrentThread.ManagedThreadId);
            }

            stopWatch.Stop();
            Console.WriteLine(" Foreach Total RunTime " +
                String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                stopWatch.Elapsed.Hours,
                stopWatch.Elapsed.Minutes,
                stopWatch.Elapsed.Seconds,
                stopWatch.Elapsed.Milliseconds / 10)
                );



            Console.WriteLine("--- Parallel Foreach -------");
            stopWatch.Restart();
            Parallel.ForEach(WorkList, i =>
            {
                Thread.Sleep(1000);
                Console.WriteLine(@"{0}. Work start, Thread = {1}", i, Thread.CurrentThread.ManagedThreadId);
            });

            stopWatch.Stop();
            Console.WriteLine(" Parallel Foreach Total RunTime " +
                String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                stopWatch.Elapsed.Hours,
                stopWatch.Elapsed.Minutes,
                stopWatch.Elapsed.Seconds,
                stopWatch.Elapsed.Milliseconds / 10)
                );


            Console.ReadLine();
        }
    }
}
