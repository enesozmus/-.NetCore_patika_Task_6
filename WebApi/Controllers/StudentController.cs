using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.StudentOperations.Commands.CreateStudent;
using WebApi.Application.StudentOperations.Commands.DeleteStudent;
<<<<<<< HEAD
using WebApi.Application.StudentOperations.Commands.UpdateStudent;
=======
>>>>>>> 059afec4f1586d874d6656d52a0ae5a59233c77e
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

<<<<<<< HEAD

        // ***** GET ***** //
=======
>>>>>>> 059afec4f1586d874d6656d52a0ae5a59233c77e
        [HttpGet]
        public IActionResult GetStudents()
        {
            GetStudentsQuery studentsQuery = new GetStudentsQuery(_context, _mapper);
            var result = studentsQuery.Handle();
            return Ok(result);
        }

<<<<<<< HEAD

        // ***** GET {id} ***** //
=======
>>>>>>> 059afec4f1586d874d6656d52a0ae5a59233c77e
        [HttpGet("{id}")]
        public IActionResult GetStudentDetail(int id)
        {
            GetStudentDetailQuery query = new GetStudentDetailQuery(_context, _mapper);
<<<<<<< HEAD
            query.studentId = id;
=======
            query.StudentId = id;
>>>>>>> 059afec4f1586d874d6656d52a0ae5a59233c77e
            GetStudentDetailQueryValidator validator = new GetStudentDetailQueryValidator();
            validator.ValidateAndThrow(query);
            var result = query.Handle();
            return Ok(result);
        }

<<<<<<< HEAD
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


=======
>>>>>>> 059afec4f1586d874d6656d52a0ae5a59233c77e
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
<<<<<<< HEAD
                return Ok("Ogrenci basariyla silindi!");
            return BadRequest();
        }
    }
}
=======
                return Ok();
            return BadRequest();
        }

        // ***** under development ***** //
        // ***** CREATE ***** //
        //[HttpPost]
        //public IActionResult AddStudent([FromBody] CreateStudentModel newStudent)
        //{

        //    CreateStudentCommand command = new CreateStudentCommand(_context, _mapper);
        //    command.Model = newStudent;

        //    CreateStudentCommandValidator validator = new CreateStudentCommandValidator();
        //    validator.ValidateAndThrow(command);

        //    return Ok();
        //}
    }
}
>>>>>>> 059afec4f1586d874d6656d52a0ae5a59233c77e
