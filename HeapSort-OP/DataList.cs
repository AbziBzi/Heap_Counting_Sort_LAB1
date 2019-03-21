using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALG_LAB_1
{
    abstract class DataList
    {
        protected int length;
        public int Length { get { return length; } }
        public abstract int Head();
        public abstract int Next();
        public abstract int Current();
        public abstract void Set(int index, int data);
        public abstract void Change(int data);
        public abstract int Get(int index);
        public abstract int Min();
        public abstract int Max();

        public void Print(int n)
        {
            Console.Write(" {0} ", Head());
            for (int i = 1; i < n; i++)
                Console.Write(" {0} ", Next());
            Console.WriteLine();
        }

    }
}
