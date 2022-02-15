using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AdvisoryTeacherOperations.Queries.GetAdvisoryTeachers
{
    public class GetTeachersQuery
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;
        public int studentId { get; set; }
        public GetTeachersQuery(SchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<TeachersViewModel> Handle()
        {
            var TeacherList = _context.AdvisoryTeachers
                                    .OrderBy(s => s.AdvisoryId)
                                    .ToList<AdvisoryTeacher>();

            List<TeachersViewModel> vm = _mapper.Map<List<TeachersViewModel>>(TeacherList);
            return vm;
        }
    }

    public class TeachersViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
