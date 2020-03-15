using System;
using System.Collections.Generic;
using System.Text;
namespace FirstUnitTest
{
    public class BubbleSort
    {
        int[] data;

        public BubbleSort(int[] value) //Constructor always be a class name
        {

            data = value;


        }

        public void binarySort() ///worst code to spend more time by the thread
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
    }

}