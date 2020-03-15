using System;
using System.Collections.Generic;
using System.Text;

namespace ClassInterface
{
    interface IMyInterface
    {
        void Train(double[] data);
        object GetResult();
        void Save();
        object[] Load();
    }
}
