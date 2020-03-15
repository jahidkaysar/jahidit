using System;
using System.Diagnostics;

namespace lab9
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] names = { "dfdhjf", "zzzzz" };

            //SecquentialExecution se = new SecquentialExecution(names);
            //se.doWork();
            ////
            ///
            ParallelTaskExecution parallelEx = new ParallelTaskExecution();
            Stopwatch s = new Stopwatch();
            s.Start();

            parallelEx.sequentialExec(50); /// equivalent to 50 thread work

            s.Stop();
            Console.WriteLine("Sequential approch, elasped time -> {0}", s.ElapsedMilliseconds);

            s.Restart();
            parallelEx.startThread(6); ///TODO:workload 6 now, it has to be 6*8
            s.Stop();
            Console.WriteLine("Thread approch, 6 cores, 6 threads, elasped time -> {0}", s.ElapsedMilliseconds);

            s.Restart();
            parallelEx.startThread(50);
            s.Stop();
            Console.WriteLine("Thread approch, 50 threads, elasped time -> {0}", s.ElapsedMilliseconds);

            s.Restart();
            parallelEx.startTask(50);
            s.Stop();
            Console.WriteLine("Task approch, 50 Tasks, elasped time -> {0}", s.ElapsedMilliseconds);

        }
    }
}