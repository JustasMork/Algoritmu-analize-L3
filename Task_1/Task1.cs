
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace L3
{
    class Task1
    {
        public static void runTest(int seed)
        {
            int m, n;

            Console.WriteLine("Enter number of arrays:");
            string input = Console.ReadLine();
            if (!Int32.TryParse(input.Trim(), out m))
            {
                Console.WriteLine("Conversion to INT failed");
                return;
            }

            Console.WriteLine("Enter number of elements in each array:");
            input = Console.ReadLine();
            if (!Int32.TryParse(input.Trim(), out n))
            {
                Console.WriteLine("Conversion to INT failed");
                return;
            }

            MyDataArray[] arrayOne = new MyDataArray[m];
            MyDataArray[] arrayTwo = new MyDataArray[m];

            for (int i = 0; i < m; i++)
            {
                arrayOne[i] = new MyDataArray(m, seed + i);
                arrayTwo[i] = new MyDataArray(m, seed + i);
            }

            var watch = new Stopwatch();
            watch.Start();
            testSequentialSort(arrayOne);
            watch.Stop();
            Console.WriteLine("\nSequential sort test => Arrays:{0}, Elements in array: {1}, Time: {2}", m, n, watch.Elapsed);

            watch.Reset();
            watch.Start();
            testParallelSort(arrayTwo);
            watch.Stop();
            Console.WriteLine("\nParallel sort test => Arrays:{0}, Elements in array: {1}, Time: {2}", m, n, watch.Elapsed);
        }

        private static void testSequentialSort(MyDataArray[] arrays)
        {
            foreach (MyDataArray array in arrays)
                Sort(array);
        }

        private static void testParallelSort(MyDataArray[] arrays)
        {
            int numberOfCPUs = 4;
            Task[] tasks = new Task[numberOfCPUs];
            for (int i = 0; i < numberOfCPUs; i++)
            {
                tasks[i] = Task.Factory.StartNew(
                    (object p) => {
                        for (int j = 0; j < arrays.Count(); j += numberOfCPUs)
                        {
                            Sort(arrays[j]);
                        }
                    }    
                , i);
            }

            Task.WaitAll(tasks);
        }
       

        private static void Sort(DataArray items)
        {
            int minVal;
            int minIndex;
            for (int i = 0; i < items.Length - 1 ; i++) {
                minVal = items[i];
                minIndex = i;
                for (int j = i; j < items.Length; j++) {
                    if (minVal > items[j])
                    {
                        minVal = items[j];
                        minIndex = j;
                    }
                }
                items.Swap(i, minIndex, items[i], minVal);
            }
        }
    }
}
