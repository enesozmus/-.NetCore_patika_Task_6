using AutoMapper;
<<<<<<< HEAD
using WebApi.Application.AdvisoryTeacherOperations.Commands.CreateTeacher;
using WebApi.Application.AdvisoryTeacherOperations.Queries.GetAdvisoryTeachers;
using WebApi.Application.AdvisoryTeacherOperations.Queries.GetTeacherDetail;
using WebApi.Application.CourseOperations.Commands.CreateCourse;
using WebApi.Application.CourseOperations.Queries.GetCourseDetail;
using WebApi.Application.CourseOperations.Queries.GetCourses;
=======
>>>>>>> 059afec4f1586d874d6656d52a0ae5a59233c77e
using WebApi.Application.StudentOperations.Commands.CreateStudent;
using WebApi.Application.StudentOperations.Queries.GetStudentDetail;
using WebApi.Application.StudentOperations.Queries.GetStudents;
using WebApi.Entities;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
<<<<<<< HEAD
            // ***** Student ***** //

=======
>>>>>>> 059afec4f1586d874d6656d52a0ae5a59233c77e
            // Get Students
            CreateMap<Student, StudentsViewModel>()
                .ForMember(x => x.AdvisoryTeacher, opt => opt
                .MapFrom(src => src.AdvisoryTeacher.FirstName + " " + src.AdvisoryTeacher.LastName));

<<<<<<< HEAD
=======

>>>>>>> 059afec4f1586d874d6656d52a0ae5a59233c77e
            // Get Student Detail
            CreateMap<Student, StudentDetailViewModel>()
                .ForMember(x => x.Courses, opt => opt.MapFrom(src => src.StudentCourses.Select(sc => sc.Course).ToList()))
                .ForMember(x => x.AdvisoryTeacher, opt => opt
                .MapFrom(src => src.AdvisoryTeacher.FirstName + " " + src.AdvisoryTeacher.LastName))
                .ForMember(x => x.Book, opt => opt
                .MapFrom(src => src.Book != null ? src.Book.Where(m => m.StudentId == src.StudentId).ToList() : null));

            CreateMap<Course, StudentDetailViewModel.StudentCourseVM>();

<<<<<<< HEAD
            // Create Student
            CreateMap<CreateStudentModel, Student>();


            // ***** AdvisoryTeacher ***** //

            // Get AdvisoryTeachers
            CreateMap<AdvisoryTeacher, TeachersViewModel>();

            // Get AdvisoryTeacher Detail
            CreateMap<AdvisoryTeacher, TeacherDetailViewModel>();

            // Create AdvisoryTeacher
            CreateMap<CreateTeacherModel, AdvisoryTeacher>();


            // ***** Course ***** //

            // Get Courses
            CreateMap<Course, CoursesViewModel>();

            // Get Course Detail
            CreateMap<Course, CourseDetailViewModel>();

            // Create Course
            CreateMap<CreateCourseModel, Course>();
=======

            // ***** under development ***** //
            // Create Student
            //CreateMap<CreateStudentModel, Student>();
>>>>>>> 059afec4f1586d874d6656d52a0ae5a59233c77e
        }
    }
}