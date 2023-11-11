//using System;
//using System.Linq;

//public interface IStudent
//{
//    string Name { get; set; }
//    string FullName { get; set; }
//    int[] Grades { get; set; }

//    string GetName();
//    string GetFullName();
//    double GetAvgGrade();
//}

//public class Student : IStudent
//{
//    public string Name { get; set; }
//    public string FullName { get; set; }
//    public int[] Grades { get; set; }

//    public Student(string name, string fullName, int[] grades)
//    {
//        Name = name;
//        FullName = fullName;
//        Grades = grades;
//    }

//    public string GetName()
//    {
//        return Name;
//    }

//    public string GetFullName()
//    {
//        return FullName;
//    }

//    public double GetAvgGrade()
//    {
//        if (Grades == null || Grades.Length == 0)
//        {
//            throw new InvalidOperationException("No grades are available to calculate the average.");
//        }
//        return Grades.Average();
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        var student = new Student("Alex", "Alex Merser", new int[] { 90, 85, 93, 88 });
//        Console.WriteLine($"Name: {student.GetName()}");
//        Console.WriteLine($"Full Name: {student.GetFullName()}");
//        Console.WriteLine($"Average Grade: {student.GetAvgGrade()}");
//    }
//}
