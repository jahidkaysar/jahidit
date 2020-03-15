using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace lab9
{
    public class ParallelTaskExecution
    {


        Random random;
        int numberOfThreadFinished = 0;


        public ParallelTaskExecution()
        {

            random = new Random();

        }

        public void onFinishDelegate(string threadName)
        {
            //Console.WriteLine($"{threadName} is finished");
            Interlocked.Increment(ref numberOfThreadFinished);
        }

        private int getRandomNumber()
        {
            return random.Next(0, 1000000);
        }
        private void print(int[] data)
        {
            foreach (var e in data) Console.Write("  " + e + "  ");
            Console.WriteLine();
        }

        private void bubblesort(int[] data) ///worst code to spend more time by the thread
        {
            for (int i = 0; i < data.Length - 1; i++)
                for (int j = i + 1; j < data.Length; j++)
                    if (data[i] > data[j])
                    {
                        int temp = data[i];
                        data[i] = data[j];
                        data[j] = temp;
                    }
        }

        public void sequentialExec(int numberOfThreads)
        {
            for (int i = 0; i < numberOfThreads; i++) doWork(null);
        }


        private void doWork(object onFinishDelegate)
        {

            int dataSize = 10000;
            int[] data = new int[dataSize];
            while (dataSize-- != 0)
            {
                data[dataSize] = getRandomNumber();
            }

            bubblesort(data); ///O(n*n) implementation to spend time on that task

            if (onFinishDelegate != null)
            {
                ((Action<string>)onFinishDelegate)(Thread.CurrentThread.Name);
            }

        }


        public void startThread(int numberOfThreads)
        {
            numberOfThreadFinished = 0; ///reset counter

            for (int i = 0; i < numberOfThreads; i++)
            {
                Thread t = new Thread(new ParameterizedThreadStart(doWork));
                t.Name = "Child Thread " + i;
                t.Start(new Action<string>(onFinishDelegate)); ///it is a delegate, created with Action


            }
            while (true) /// keep main thread waiting until all the threads are finished
            {
                if (numberOfThreadFinished == numberOfThreads) break;
                Thread.Sleep(400);
            }
        }

        public void startTask(int numberOfThreads)
        {
            List<Task> tasks = new List<Task>();
            var action = new Action<string>(onFinishDelegate);
            for (int i = 0; i < numberOfThreads; i++)
            {
                tasks.Add(new Task(new Action<object>(doWork), new Action<string>(onFinishDelegate)));

            }
            foreach (Task t in tasks) t.Start();

            Task.WaitAll(tasks.ToArray());
        }


    }
}