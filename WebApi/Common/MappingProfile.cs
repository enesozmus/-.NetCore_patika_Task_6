using AutoMapper;
using WebApi.Application.AdvisoryTeacherOperations.Commands.CreateTeacher;
using WebApi.Application.AdvisoryTeacherOperations.Queries.GetAdvisoryTeachers;
using WebApi.Application.AdvisoryTeacherOperations.Queries.GetTeacherDetail;
using WebApi.Application.CourseOperations.Commands.CreateCourse;
using WebApi.Application.CourseOperations.Queries.GetCourseDetail;
using WebApi.Application.CourseOperations.Queries.GetCourses;
using WebApi.Application.ExamOperations.Queries.GetExamDetail;
using WebApi.Application.ExamOperations.Queries.GetExams;
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
            // ***** Student ***** //

                // Get Students
                CreateMap<Student, StudentsViewModel>()
                    .ForMember(x => x.AdvisoryTeacher, opt => opt
                    .MapFrom(src => src.AdvisoryTeacher.FirstName + " " + src.AdvisoryTeacher.LastName));

                // Get Student Detail
                CreateMap<Student, StudentDetailViewModel>()
                    .ForMember(x => x.Courses, opt => opt.MapFrom(src => src.StudentCourses.Select(sc => sc.Course).ToList()))
                    .ForMember(x => x.AdvisoryTeacher, opt => opt
                    .MapFrom(src => src.AdvisoryTeacher.FirstName + " " + src.AdvisoryTeacher.LastName))
                    .ForMember(x => x.Exam, opt => opt
                    .MapFrom(src => src.Exam != null ? src.Exam.Where(m => m.StudentId == src.StudentId).ToList() : null));

                CreateMap<Course, StudentDetailViewModel.StudentCourseVM>();

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


            // ***** Exam ***** //

                // Get Exams
                CreateMap<Exam, ExamsViewModel>();

                // Get Exam Detail 
                CreateMap<Exam, ExamDetailViewModel>();
        }
    }
}