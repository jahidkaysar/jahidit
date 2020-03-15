using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ClassInterface
{
    class ClassTwo : IMyInterface
    {

        double sum = 0;

        int total;
        double average;
        double median;
        double sos = 0.0;
        double populationvariance;
        double samplevariance;


        public object GetResult()
        {
            return (median, average, populationvariance, samplevariance);
        }

        public object[] Load()
        {
            object[] final = new object[4];
            final[0] = File.ReadAllText("CalMedian.txt");
            final[1] = File.ReadAllText("CalAverage.txt");
            final[2] = File.ReadAllText("CalPopulationVariance.txt");
            final[3] = File.ReadAllText("CalSampleVariance.txt");

            return final;
        }

        public void Save()
        {
            if (!File.Exists("CalMedian.txt"))
            {
                File.Create("CalMedian.txt");
            }


            if (!File.Exists("CalAverage.txt"))
            {
                File.Create("CalAverage.txt");
            }

            if (!File.Exists("CalPopulationVariance.txt"))
            {
                File.Create("CalPopulationVariance.txt");
            }

            if (!File.Exists("CalSampleVariance.txt"))
            {
                File.Create("CalSampleVariance.txt");
            }
            File.WriteAllText("CalMedian.txt", median.ToString());
            File.WriteAllText("CalAverage.txt", average.ToString());
            File.WriteAllText("CalPopulationVariance.txt", populationvariance.ToString());
            File.WriteAllText("CalSampleVariance.txt", samplevariance.ToString());
        }

        public void Train(double[] data)
        {
            total = ((data.Length + 1) / 2 - 1);


            foreach (var item in data)
            {
                sum += item;
            }
            Array.Sort(data);

            foreach (var value in data)
            {


            }



            median = data[total];





            average = sum / data.Length;


            foreach (var num in data)
            {
                sos += Math.Pow((num - average), 2);
            }
            populationvariance = sos / data.Length; // calculate population variance
                                                    // Console.WriteLine("population variance is:  " + populationvariance);

            foreach (var num in data)
            {
                sos += Math.Pow((num - average), 2);//For each Number in the array subtract it with mean value
            }                                               //and square it.
            samplevariance = sos / (data.Length - 1);//Then devide it by total length of the array.
                                                     // Console.WriteLine("Sample variance is:  " + samplevariance);
        }
    }
}
