using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALG_LAB_1
{
    class MyDataArray : DataArray
    {
        int[] data;

        public MyDataArray(int n)
        {
            data = new int[n];
        }

        public MyDataArray(int n, int seed)
        {
            data = new int[n];
            length = n;
            Random rand = new Random(seed);
            for (int i = 0; i < length; i++)
            {
                data[i] = rand.Next(10000);
            }
        }

        public override int this[int index]
        {
            get {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }
    }
}
