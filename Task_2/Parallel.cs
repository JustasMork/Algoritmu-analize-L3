using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3
{
    class Parallel: AlgorythmParent
    {
        private int numberOfCPUs = 4;
        public Parallel(int[] p)
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
                int numberOfThreads = numberOfCPUs;
                int min = -1;
                int recursionResult = runAlgorythm(k - 1, n - 1);
                for (int i = 1; i <= n; i += numberOfCPUs)
                {
                    if (n - i < numberOfCPUs)
                        numberOfThreads = n - i;

                    if (numberOfThreads <= 0)
                        continue;

                    Task<int>[] tasks = new Task<int>[numberOfThreads];
                    for (int j = 0; j < numberOfThreads; j++)
                    {
                        tasks[j] = Task<int>.Factory.StartNew(
                            (object p) => { return getSumOfElements(n, (int)p); }
                         , i + j);
                    }
                    Task.WaitAll(tasks);
                    int[] sumResults = new int[numberOfThreads];

                    for (int j = 0; j < numberOfThreads; j++)
                    {
                        sumResults[j] = tasks[j].Result;
                    }

                    int sum = sumResults.Min();

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
