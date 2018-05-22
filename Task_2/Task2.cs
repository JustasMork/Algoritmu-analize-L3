using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3
{
    class Task2
    {
        private static int maxIntValue = 1000;
        public static void runTest(int seed)
        {

            int n, k, nn;

            Console.WriteLine("Enter length of p:");
            string input = Console.ReadLine();

            if (!Int32.TryParse(input.Trim(), out n))
            {
                Console.WriteLine("Conversion to INT failed");
                return;
            }

            int[] p = new int[n];
            Random rnd = new Random(seed);
            for (int i = 0; i < n; i++)
            {
                p[i] = rnd.Next(Task2.maxIntValue);
            }

            Console.WriteLine("Enter k:");
            input = Console.ReadLine();
            if (!Int32.TryParse(input.Trim(), out k))
            {
                Console.WriteLine("Conversion to INT failed");
                return;
            }

            Console.WriteLine("Enter n:");
            input = Console.ReadLine();
            if (!Int32.TryParse(input.Trim(), out nn))
            {
                Console.WriteLine("Conversion to INT failed");
                return;
            }

            Console.WriteLine("\nRecursive Task2");
            Recursive recursive = new Recursive(p);
            var watch = new Stopwatch();
            watch.Start();
            Console.WriteLine(recursive.runAlgorythm(k, nn));
            watch.Stop();
            Console.WriteLine(watch.Elapsed);

            Console.WriteLine("\nParallel Task2");
            Parallel parallel = new Parallel(p);
            watch.Reset();
            watch.Start();
            Console.WriteLine(parallel.runAlgorythm(k, nn));
            watch.Stop();
            Console.WriteLine(watch.Elapsed);


        }
    }
}
