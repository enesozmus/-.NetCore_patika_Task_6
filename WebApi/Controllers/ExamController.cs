using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
