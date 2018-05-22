using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3
{
    abstract class DataArray 
    {
        protected int length;
        public int Length { get { return length; } }
        public abstract int this[int index] { get; }
        public abstract void set(int index, int value);
        public abstract void Swap(int i, int j, int a, int b);
        public void Print(int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write(" {0} ", this[i]);
            Console.WriteLine();
        }
    }
}
