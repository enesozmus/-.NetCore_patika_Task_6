using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.ExamOperations.Queries.GetExams
{
    public class GetExamsQuery
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;
        public int examId { get; set; }
        public GetExamsQuery(SchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ExamsViewModel> Handle()
        {
            var examList = _context.Exams
                                    .OrderBy(s => s.ExamId)
                                    .ToList<Exam>();

            List<ExamsViewModel> vm = _mapper.Map<List<ExamsViewModel>>(examList);
            return vm;
        }
    }

    public class ExamsViewModel
    {
        public int ExamId { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public int StudentId { get; set; }
    }
}
