using System;

namespace Task1 
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var student = new Student("Белоусов", "Егор", "Леонидович", "М8О-208Б-21", "C#");
            var student1 = new Student("Белоусов", "Егор", "Леонидович", "М8О-208Б-21", "C#");
            var student2 = new Student("Захаров", "Василий", "Анатольевич", "М8О-208Б-21", "C#");
            Console.WriteLine(student.Equals(student1)); // True
            Console.WriteLine(student.Equals(student2)); // False
            Console.WriteLine(student); // Белоусов Егор Леонидович М8О-208Б-21 C#
            Console.WriteLine(student.CourseNumber); // 2
        }
    }
}