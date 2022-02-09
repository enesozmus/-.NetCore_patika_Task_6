using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.StudentOperations.Queries.GetStudents
{
    public class GetStudentsQuery
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;
        public int studentId { get; set; }
        public GetStudentsQuery(SchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<StudentsViewModel> Handle()
        {
            var studentList = _context.Students
                                    .Include(x => x.AdvisoryTeacher)
                                    .OrderBy(s => s.StudentId)
                                    .ToList<Student>();

            List<StudentsViewModel> vm = _mapper.Map<List<StudentsViewModel>>(studentList);
            return vm;
        }
    }

    public class StudentsViewModel
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Number { get; set; }
        public DateTime Birthday { get; set; }
        public string AdvisoryTeacher { get; set; }
    }
}
