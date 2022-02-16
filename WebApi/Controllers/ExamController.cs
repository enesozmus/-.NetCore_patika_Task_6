using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ExamOperations.Queries.GetExamDetail;
using WebApi.Application.ExamOperations.Queries.GetExams;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;
        public ExamController(SchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // ***** GET All ***** //
        [HttpGet]
        public IActionResult GetExams()
        {
            GetExamsQuery examsQuery = new GetExamsQuery(_context, _mapper);
            var result = examsQuery.Handle();
            return Ok(result);
        }


        // ***** GET {id} ***** //
        [HttpGet("{id}")]
        public IActionResult GetExamDetail(int id)
        {
            GetExamDetailQuery query = new GetExamDetailQuery(_context, _mapper);
            query.examId = id;

            GetExamDetailQueryValidator validator = new GetExamDetailQueryValidator();
            validator.ValidateAndThrow(query);
            var result = query.Handle();
            return Ok(result);
        }
    }
}
