using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3
{
    class Recursive: AlgorythmParent
    {
        public Recursive(int[] p)
        {
            this.p = p;
        }

        public override int runAlgorythm(int k, int n)
        {
            if (n == 0)
                return 0;
            else if (k == 1)
            {
                int result = getSumOfElements(n, 0);
                return result;
            }
            else
            {
                int min = -1;
                int recursionResult = runAlgorythm(k - 1, n - 1);
                for (int i = 1; i < n; i++)
                {
                    int sum = getSumOfElements(n, i);
                    

                    if (sum > recursionResult)
                    {
                        if (min > sum || min == -1)
                            min = sum;
                    }
                    else
                    {
                        if (min > recursionResult || min == -1)
                            min = recursionResult;
                    }
                }
                return min;
            }
        }


    }
}
