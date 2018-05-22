using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3
{
    class Search
    {


        public static void runTest(int seed)
        {
            
            int n, m;

            Console.WriteLine("Enter number of elements in RB-Tree:");
            string input = Console.ReadLine();
            
            if (!Int32.TryParse(input.Trim(), out n))
            {
                Console.WriteLine("Conversion to INT failed");
                return;
            }
                

            Student[] studentsList = RandomStudentGenerator.GenerateStudents(seed, n);

            MyDataTree students = new MyDataTree();
            foreach (Student student in studentsList)
                students.add(student);

            Console.WriteLine("Enter number of searched elments:");
            input = Console.ReadLine();

            if (!Int32.TryParse(input.Trim(), out m))
            {
                Console.WriteLine("Conversion to INT failed");
                return;
            }
                

            Student[] studentsToFind = selectRandomStudents(m, studentsList);

            var watch = new Stopwatch();
            watch.Start();
            int result = testSequential(students, studentsToFind);
            watch.Stop();
            Console.WriteLine("\nSequential test => Time: {0}, Elements found: {1}, Total elements: {2}", watch.ElapsedMilliseconds, result, n);

            watch.Reset();
            watch.Start();
            result = testParralel(students, studentsToFind);
            watch.Stop();
            Console.WriteLine("\nParralel test => Time: {0}, Elements found: {1}, Total elements: {2}", watch.ElapsedMilliseconds, result, n);

        }

        private static int testSequential(MyDataTree students, Student[] studentsToFind)
        {
            int counter = 0;
            foreach (Student student in studentsToFind)
                if(SearchInTree(students, student) != null){ counter++; }

            return counter;
        }

        private static int testParralel(MyDataTree students, Student[] studentsToFind)
        {
            int countCPU = 1;
            Task<int>[] tasks = new Task<int>[countCPU];
            for (int i = 0; i < countCPU; i++)
            {
                tasks[i] = Task<int>.Factory.StartNew(
                    (object p) => 
                    {
                        int counter = 0;
                        for (int j = (int)p; j < studentsToFind.Count(); j += countCPU)
                        {
                            SearchInTree(students, studentsToFind[j]);
                            counter++;
                        }
                           

                        return counter;
                    }, i);
            }
            
            int total = 0;
            foreach (Task<int> task in tasks)
                total += task.Result;
            return total;

        }

        private static Student[] selectRandomStudents(int numberToSelect, Student[] students)
        {

            Random random = new Random();
            Student[] selectedStudents = new Student[numberToSelect];
            int counter = 0;
            while (counter < numberToSelect)
                selectedStudents[counter++] = students[random.Next(students.Count())];


            return selectedStudents;
        }

        public static Student SearchInTree(MyDataTree students, Student studentToFind)
        {
            if (students.isEmpty() || studentToFind == null || studentToFind == null)
                return null;

            Student foundStudent = null;
            bool finished = false;
            students.setToRoot();

            while ((students.hasLeft() || students.hasRight()) && !finished)
            {
                if (students.getData().CompareTo(studentToFind) == 1)
                {
                    if (students.hasLeft())
                        students.left();
                    else
                        finished = true;
                }
                else if (students.getData().CompareTo(studentToFind) == -1)
                {
                    if (students.hasRight())
                        students.right();
                    else
                        finished = true;
                }

                if (students.getData() != null && students.getData().CompareTo(studentToFind) == 0)
                {
                    foundStudent = students.getData();
                    finished = true;
                }
            }
            return foundStudent;
        }



    }
}
