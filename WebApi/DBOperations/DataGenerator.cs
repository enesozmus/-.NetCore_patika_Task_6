using System;
using System.Linq;
using WebApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SchoolDbContext(serviceProvider.GetRequiredService<DbContextOptions<SchoolDbContext>>()))
            {
                if (context.AdvisoryTeachers.Any() || context.Students.Any() || context.Books.Any())
                {
                    return;
                }

                context.Students.AddRange(
                    new Student
                    {
                        FirstName = "Enes",
                        LastName = "Ozmus",
                        Birthday = new DateTime(1997, 08, 01),
                        Number = 100
                    },
                    new Student
                    {
                        FirstName = "Ahmet",
                        LastName = "Demir",
                        Birthday = new DateTime(1998, 06, 01),
                        Number = 101

                    },
                    new Student
                    {
                        FirstName = "Çağlar",
                        LastName = "Bayrakçı",
                        Birthday = new DateTime(1999, 06, 01),
                        Number = 102

                    },
                    new Student
                    {
                        FirstName = "Selim",
                        LastName = "Karaca",
                        Birthday = new DateTime(2000, 04, 01),
                        Number = 103
                    });

                context.AdvisoryTeachers.AddRange(
                        new AdvisoryTeacher
                        {
                            AdvisoryId = 1,
                            FirstName = "teacher's name",
                            LastName = "1111",
                            StudentId = 1
                        },
                        new AdvisoryTeacher
                        {
                            AdvisoryId = 2,
                            FirstName = "teacher's name",
                            LastName = "22222",
                            StudentId = 2
                        },
                        new AdvisoryTeacher
                        {
                            AdvisoryId = 3,
                            FirstName = "teacher's name",
                            LastName = "3333",
                            StudentId = 3
                        },
                        new AdvisoryTeacher
                        {
                            AdvisoryId = 4,
                            FirstName = "teacher's name",
                            LastName = "4444",
                            StudentId = 4
                        });

                context.Books.AddRange(
                        new Book
                        {
                            Author = "author_1",
                            Name = "book_1",
                            StudentId = 2
                        },
                        new Book
                        {
                            Author = "author_2",
                            Name = "book_2",
                            StudentId = 2

                        },
                        new Book
                        {
                            Author = "author_3",
                            Name = "book_3",
                            StudentId = 2

                        },
                        new Book
                        {
                            Author = "author_4",
                            Name = "book_4",
                            StudentId = 2
                        });
                
                context.Courses.AddRange(
                        new Course
                        {
                            Name = "course_1"
                        },
                        new Course
                        {
                            Name = "course_2"
                        });

                context.StudentCourses.AddRange(
                    new StudentCourse
                    {
                        CourseId = 1,
                        StudentId = 2
                    },
                    new StudentCourse
                    {
                        CourseId = 2,
                        StudentId = 2
                    });
                context.SaveChanges();
            }
        }
    }
}