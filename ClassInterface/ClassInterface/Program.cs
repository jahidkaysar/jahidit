using System;

namespace ClassInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] data = { 1.0, 2.0, 3.0, 4.0, 5.0 };

            IMyInterface myInterface = new ClassOne();
            myInterface.Train(data);

            myInterface.Save();
            var result1 = myInterface.GetResult();
            Console.WriteLine("\nThe Sum is :   " + result1);





            IMyInterface myInterface1 = new ClassTwo();
            myInterface1.Train(data);
            var result2 = myInterface1.GetResult().ToString();


            var first = result2.Split(",");
            var second = first[0];
            var third = first[1];
            var forth = first[2];
            Console.WriteLine("Median is : " + second);
            Console.WriteLine("Average is : " + third);
            Console.WriteLine("Variance is : " + forth);
            myInterface1.Save();

            object[] loadedvalue1 = new object[1];
            loadedvalue1 = myInterface.Load();
            Console.WriteLine("\nSum from file: " + loadedvalue1[0]);

            object[] loadedvalue = new object[4];
            loadedvalue = myInterface1.Load();
            Console.WriteLine("\nMedian from file : " + loadedvalue[0]);
            Console.WriteLine(" Average from file : " + loadedvalue[1]);
            Console.WriteLine(" Variance from file: " + loadedvalue[2]);


            Console.ReadKey();
        }
    }
}
