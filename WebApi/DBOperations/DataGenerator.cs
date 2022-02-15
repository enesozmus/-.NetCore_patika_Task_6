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
<<<<<<< HEAD
                            FirstName = "teacher's name",
                            LastName = "1111",
=======
                            FirstName = "advisoryname",
                            LastName = "lastname",
>>>>>>> 059afec4f1586d874d6656d52a0ae5a59233c77e
                            StudentId = 1
                        },
                        new AdvisoryTeacher
                        {
                            AdvisoryId = 2,
<<<<<<< HEAD
                            FirstName = "teacher's name",
                            LastName = "22222",
=======
                            FirstName = "advisoryname",
                            LastName = "lastname",
>>>>>>> 059afec4f1586d874d6656d52a0ae5a59233c77e
                            StudentId = 2
                        },
                        new AdvisoryTeacher
                        {
                            AdvisoryId = 3,
<<<<<<< HEAD
                            FirstName = "teacher's name",
                            LastName = "3333",
=======
                            FirstName = "advisoryname",
                            LastName = "lastname",
>>>>>>> 059afec4f1586d874d6656d52a0ae5a59233c77e
                            StudentId = 3
                        },
                        new AdvisoryTeacher
                        {
                            AdvisoryId = 4,
<<<<<<< HEAD
                            FirstName = "teacher's name",
                            LastName = "4444",
=======
                            FirstName = "advisoryname",
                            LastName = "lastname",
>>>>>>> 059afec4f1586d874d6656d52a0ae5a59233c77e
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