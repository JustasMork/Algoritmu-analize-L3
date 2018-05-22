using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3
{
    class Program
    {
        static void Main(string[] args)
        {
            int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;

            Console.WriteLine("Select action (1 - Task_1, 2 - Task_2)");
            switch (Console.ReadLine().Trim().ToLower())
            {
                case "1":
                    Search.runTest(seed);
                    break;
                case "2":
                    Task2.runTest(seed);
                    break;
                default:
                    Console.WriteLine("Unknown action");
                    break;
            }
        }
    }
}
