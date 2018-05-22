using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3
{
    class RandomStudentGenerator
    {
        private static string[] firstNames = { "Jonas", "Petras", "Vardenis", "Algimantas", "Steponas", "Vytautas", "Paulius"};
        private static string[] lastNames = { "Jonaitis", "Petraitis", "Pavardenis", "Algimantauskas", "Steponavicius", "Vytautaitis", "Paulauskas" };
        private static string[] groupLetters = { "AA-6/", "AA-5/", "BB-6/", "BB-5/", "CC-6/", "CC-5/", "DD-6/", "DD-5/", "EE-6/", "EE-5/" };
        private static string[] facultyNames = {"Informatikos", "Matematikos", "Mechanikos", "Elektronikos", "Dizaino", "Ekonomikos", "Humanitarinių mokslų"};

        public static Student[] GenerateStudents(int seed, int numberOfStudents)
        {
            Student[] students = new Student[numberOfStudents];
            Random random = new Random(seed);
            for (int i = 0; i < numberOfStudents; i++)
            {
                Student newStudent = new Student(firstNames[random.Next(firstNames.Length)]+" "+lastNames[random.Next(lastNames.Length)], groupLetters[random.Next(groupLetters.Length)]+random.Next(12), facultyNames[random.Next(facultyNames.Length)], i);
                students[i] = newStudent;
            }
            Shuffle<Student>(ref students);
            return students;
        }

        private static void Shuffle<T>(ref T[] array)
        {
            Random rng = new Random();
            int n = array.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
    }
}
