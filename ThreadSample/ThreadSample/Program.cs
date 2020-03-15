using System;
using System.Diagnostics;
using System.Threading;

namespace ThreadSample
{
    class Program
    {
        static int numThreads = 150;

        static void Main(string[] args)
        {
            Console.WriteLine("Press any Key to start.");
            Console.ReadKey();
            //Console.ReadLine();

            Stopwatch sw = new Stopwatch();
            sw.Start();

            ThreadDemo sample = new ThreadDemo();

            // 1. Executes all tasks sequentianally
            //sample.StartSequenced(numThreads, workerFunction);

            // 2.  Executes multiple task.
            //sample.StartMultithreadedNative(numThreads, workerFunction);

           
            sample.StartWithTpl(numThreads, workerFunction);

            sw.Stop();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0} ms", sw.ElapsedMilliseconds);

            Console.ReadLine();
        }

        private static void workerFunction(object onFinishDelegate)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"Thread found : {Thread.CurrentThread.Name} - {Thread.CurrentThread.ManagedThreadId}");

            double r = 202020203030442;
            for (int i = 0; i < 200000; i++)
            {
                r = r * 1.94536;
            }

            if (onFinishDelegate != null)
            {
                ((Action<string>)onFinishDelegate)(Thread.CurrentThread.Name);
            }

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("Stopped thread: {0}", Thread.CurrentThread.Name);
        }
    }
}