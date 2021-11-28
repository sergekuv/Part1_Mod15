using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_15_6_6
{
    class Program
    {
        static void Main(string[] args)
        {
            var classes = new[]
          {
               new Classroom { Students = {"Evgeniy", "Sergey", "Andrew"}, },
               new Classroom { Students = {"Anna", "Viktor", "Vladimir"}, },
               new Classroom { Students = {"Bulat", "Alex", "Galina"}, }
           };
            var allStudents1 = GetAllStudents1(classes);
            Console.WriteLine(string.Join(" ", allStudents1));

            var allStudents2 = GetAllStudents2(classes);
            Console.WriteLine(string.Join(" ", allStudents2));

        }

        static string[] GetAllStudents1(Classroom[] classes) =>  classes.SelectMany(c => c.Students).ToArray();

        static string[] GetAllStudents2(Classroom[] classes)
        {
            var result = (from cl in classes
                         from student in cl.Students
                         select student).ToArray();
            return result;
        }


        public class Classroom
        {
            public List<string> Students = new List<string>();
        }
    }
}
