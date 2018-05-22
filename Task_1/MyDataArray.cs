using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3
{
    class MyDataArray : DataArray
    {
        int[] array;

        public MyDataArray(int n, int seed) {
            Random random = new Random(seed);
            this.array = new int[n];
            length = n;

            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next();
            }
        }

        public MyDataArray(int n)
        {
            array = new int[n];
            length = n;
        }

        public override int this[int index]
        {
            get
            {
                return array[index];
            }
        }

        public override void set(int index, int value)
        {
            array[index] = value;          
        }

        public override void Swap(int i, int j, int a, int b)
        {
            array[i] = b;
            array[j] = a;
        }
    }
}
