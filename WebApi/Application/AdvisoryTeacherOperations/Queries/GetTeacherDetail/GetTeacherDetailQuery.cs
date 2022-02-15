using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.Application.AdvisoryTeacherOperations.Queries.GetTeacherDetail
{
    public class GetTeacherDetailQuery
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;
        public int AdvisoryId { get; set; }
        public GetTeacherDetailQuery(SchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public TeacherDetailViewModel Handle()
        {
            var teacher = _context.AdvisoryTeachers
                                        .SingleOrDefault(x => x.AdvisoryId == AdvisoryId);

            if (teacher is null)
                throw new InvalidOperationException("Aradıgınız rehber ogretmeni bulunamadi!");

            TeacherDetailViewModel vm = _mapper.Map<TeacherDetailViewModel>(teacher);
            return vm;
        }
    }

    public class TeacherDetailViewModel
    {
        public int AdvisoryId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StudentId { get; set; }
    }
}
