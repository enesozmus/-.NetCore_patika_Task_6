using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.ExamOperations.Queries.GetExamDetail
{
    public class GetExamDetailQuery
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;
        public int examId { get; set; }

        public GetExamDetailQuery(SchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ExamDetailViewModel Handle()
        {
            var exam = _context.Exams
                                        .SingleOrDefault(x => x.ExamId == examId);

            if (exam is null)
                throw new InvalidOperationException("Aradıgınız sinav sonucu bulunamadi!");

            ExamDetailViewModel vm = _mapper.Map<ExamDetailViewModel>(exam);
            return vm;
        }
    }

    public class ExamDetailViewModel
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public int StudentId { get; set; }
    }
}
