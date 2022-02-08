using AutoMapper;
using WebApi.Application.StudentOperations.Queries.GetStudentDetail;
using WebApi.Application.StudentOperations.Queries.GetStudents;
using WebApi.Entities;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentsViewModel>()
                .ForMember(x => x.AdvisoryTeacher, opt => opt
                .MapFrom(src => src.AdvisoryTeacher.FirstName + " " + src.AdvisoryTeacher.LastName))
                .ForMember(x => x.Book, opt => opt
                .MapFrom(src => src.Book !=null ? src.Book.Where(m => m.StudentId == src.StudentId).ToList() : null));


            // Get Student Detail
            CreateMap<Student, StudentDetailViewModel>()
                .ForMember(x => x.Courses, opt => opt.MapFrom(src => src.StudentCourses.Select(sc => sc.Course).ToList()))
                .ForMember(x => x.AdvisoryTeacher, opt => opt
                .MapFrom(src => src.AdvisoryTeacher.FirstName + " " + src.AdvisoryTeacher.LastName))
                .ForMember(x => x.Book, opt => opt
                .MapFrom(src => src.Book != null ? src.Book.Where(m => m.StudentId == src.StudentId).ToList() : null));

            CreateMap<Course, StudentDetailViewModel.StudentCourseVM>();
        }
    }
}