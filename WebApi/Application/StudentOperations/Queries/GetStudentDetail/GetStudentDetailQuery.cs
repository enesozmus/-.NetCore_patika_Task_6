using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.StudentOperations.Queries.GetStudentDetail
{
    public class GetStudentDetailQuery
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;
        public int studentId { get; set; }

        public GetStudentDetailQuery(SchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public StudentDetailViewModel Handle()
        {
            var student = _context.Students
                .Include(x => x.AdvisoryTeacher)
                .Include(x => x.Exam)
                .Include(s => s.StudentCourses)
                .ThenInclude(c => c.Course)
                .SingleOrDefault(x => x.StudentId == studentId);

            if (student is null)
                throw new InvalidOperationException("Aradıgınız ogrenci bulunamadi!");

            StudentDetailViewModel vm = _mapper.Map<StudentDetailViewModel>(student);
            return vm;
        }
    }
    public class StudentDetailViewModel
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string AdvisoryTeacher { get; set; }
        public List<Exam> Exam { get; set; }
        public List<StudentCourseVM> Courses { get; set; }

        public struct StudentCourseVM
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
