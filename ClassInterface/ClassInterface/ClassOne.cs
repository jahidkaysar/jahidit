using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ClassInterface
{
    class ClassOne : IMyInterface
    {
        Double sum = 0.0;
        int b;
        int result;

        public object GetResult()
        {
            return sum;
        }

        public object[] Load()
        {
            object[] final = new object[3];
            final[0] = File.ReadAllText("CalMedian.txt");

            return final;
        }

        public void Save()
        {
            if (!File.Exists("CalSum.txt"))
            {
                File.Create("CalSum.txt");

            }
            File.WriteAllText("CalSum.txt", sum.ToString());
        }

        public void Train(double[] data)
        {

            foreach (var item in data)
            {
                sum += item;
            }
            result = sum.CompareTo(100.0);
            if (result > 0)
            {
                b = 1;
            }
            else
                b = 0;

            Console.WriteLine("\nStatus is set to :  " + b);

        }
    }
}
