using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.StudentOperations.Commands.CreateStudent;
using WebApi.Application.StudentOperations.Commands.DeleteStudent;
using WebApi.Application.StudentOperations.Commands.UpdateStudent;
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


        // ***** GET All ***** //
        [HttpGet]
        public IActionResult GetStudents()
        {
            GetStudentsQuery studentsQuery = new GetStudentsQuery(_context, _mapper);
            var result = studentsQuery.Handle();
            return Ok(result);
        }


        // ***** GET {id} ***** //
        [HttpGet("{id}")]
        public IActionResult GetStudentDetail(int id)
        {
            GetStudentDetailQuery query = new GetStudentDetailQuery(_context, _mapper);
            query.studentId = id;

            GetStudentDetailQueryValidator validator = new GetStudentDetailQueryValidator();
            validator.ValidateAndThrow(query);
            var result = query.Handle();
            return Ok(result);
        }


        // ***** CREATE ***** //
        [HttpPost]
        public IActionResult AddStudent([FromBody] CreateStudentModel newStudent)
        {
            CreateStudentCommand command = new CreateStudentCommand(_context, _mapper);
            command.Model = newStudent;
            CreateStudentCommandValidator validator = new CreateStudentCommandValidator();
            validator.ValidateAndThrow(command);
            
            command.Handle();
            
            return Ok("Ogrenci basariyla eklendi!");
        }


        // ***** UPDATE ***** //
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] UpdateStudentModel updateStudent)
        {

            UpdateStudentCommand command = new UpdateStudentCommand(_context);
            command.StudentId = id;
            command.Model = updateStudent;

            UpdateStudentCommandValidator validator = new UpdateStudentCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok("Ogrenci basariyla guncellendi!");
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

                return Ok("Ogrenci basariyla silindi!");
            return BadRequest();
        }
    }
}
