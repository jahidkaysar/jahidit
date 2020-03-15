using System;

namespace FirstUnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ab = { 5, 4, 88, 22, 11, 2 };
            BubbleSort x = new BubbleSort(ab);
            x.binarySort();
            for (int i = 0; i < 6; i++)
            {

                Console.WriteLine(ab[i]);
            }
        }
    }
}