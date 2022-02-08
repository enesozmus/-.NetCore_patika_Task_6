using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.StudentOperations.Commands.DeleteStudent;
using WebApi.Application.StudentOperations.Queries.GetStudentDetail;
using WebApi.Application.StudentOperations.Queries.GetStudents;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;
        public StudentController(SchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            GetStudentsQuery studentsQuery = new GetStudentsQuery(_context, _mapper);
            var result = studentsQuery.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentDetail(int id)
        {
            GetStudentDetailQuery query = new GetStudentDetailQuery(_context, _mapper);
            query.StudentId = id;
            GetStudentDetailQueryValidator validator = new GetStudentDetailQueryValidator();
            validator.ValidateAndThrow(query);
            var result = query.Handle();
            return Ok(result);
        }

        // ***** DELETE ***** //
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            DeleteStudentCommand command = new DeleteStudentCommand(_context);
            command.StudentId = id;
            DeleteStudentCommandValidator validator = new DeleteStudentCommandValidator();
            validator.ValidateAndThrow(command);
            var result = command.Handle();
            if (result)
                return Ok();
            return BadRequest();
        }
    }
}
