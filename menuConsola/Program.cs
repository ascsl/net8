using System;
using Microsoft.EntityFrameworkCore;

namespace EjemploMenuConsola;

// Models/Course.cs
public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public Course() {
        Name = "";
        Description = "";
    }
}

// Models/Student.cs
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    // Otras propiedades...
    public Student() {
        Name = "";
        Email = "";
    }
}

// Models/Enrollment.cs
public class Enrollment
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public DateTime EnrollmentDate { get; set; }
    // Relación con Student y Course
}

public class CoursesContext : DbContext
{
    public DbSet<Course> Courses { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }

    public CoursesContext(DbContextOptions<CoursesContext> options)
        : base(options)
    {
    }
}

class Program
{
    static void Main(string[] args)
    {
        using (var context = new CoursesContext(new DbContextOptionsBuilder<CoursesContext>()
            .UseSqlServer("CadenaDeConexionBD")
            .Options))
        {
            while (true)
            {
                Console.WriteLine("1. Courses");
                Console.WriteLine("2. Students");
                Console.WriteLine("3. Enrollments");
                Console.WriteLine("4. Exit");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Courses:");
                        DisplayCourses(context);
                        break;
                    case "2":
                        Console.WriteLine("Students:");
                        DisplayStudents(context);
                        break;
                    case "3":
                        Console.WriteLine("Enrollments:");
                        //DisplayEnrollments(context);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

    }

    private static void DisplayCourses(CoursesContext context)
    {
        context.Courses.ToList().ForEach(course => Console.WriteLine($"{course.Id} - {course.Name}"));
    }

    private static void DisplayStudents(CoursesContext context)
    {
        context.Students.ToList().ForEach(student => Console.WriteLine($"{student.Id} - {student.Name}"));
    }
}
