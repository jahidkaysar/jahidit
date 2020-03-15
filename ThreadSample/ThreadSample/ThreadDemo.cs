using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSample
{
    public class ThreadDemo
    {
        private long m_FinishCounter = 0;

        
        // Starts all jobs in a single sequence.
        
        public void StartSequenced(int sequences, Action<object> func)
        {
            Thread.CurrentThread.Name = "SingleThread";

            for (int i = 0; i < sequences; i++)
            {
                func(null);
            }
        }


        
        // Starts all jobs in parallel.
        
        public void StartMultithreadedNative(int threads, Action<object> func)
        {
            for (int i = 0; i < threads; i++)
            {
                var t = new Thread(new ParameterizedThreadStart(func));
                t.Name = i.ToString();
                t.Start(new Action<string>(OnThreadFinished));
            }

            while (true)
            {
                if (Interlocked.Read(ref m_FinishCounter) == threads)
                    break;
                else
                    Thread.Sleep(500);
            }
        }


        private void OnThreadFinished(string threadName)
        {
            Interlocked.Increment(ref m_FinishCounter);
        }





     
        // Creates Tasks, then starts tasks with waiting on all of them to complete.
        
        public void StartWithTpl(int threads, Action<object> func)
        {
            List<Task> tList = new List<Task>();

            for (int i = 0; i < threads; i++)
            {
                var t = new Task(func, new Action<string>(OnThreadFinished));
                tList.Add(t);
            }

            foreach (var t in tList)
            {
                t.Start();
            }

            Task.WaitAll(tList.ToArray());
        }

    }
}