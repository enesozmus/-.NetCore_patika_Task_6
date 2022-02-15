using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.AdvisoryTeacherOperations.Commands.CreateTeacher;
using WebApi.Application.AdvisoryTeacherOperations.Commands.DeleteTeacher;
using WebApi.Application.AdvisoryTeacherOperations.Commands.UpdateTeacher;
using WebApi.Application.AdvisoryTeacherOperations.Queries.GetAdvisoryTeachers;
using WebApi.Application.AdvisoryTeacherOperations.Queries.GetTeacherDetail;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvisoryTeacherController : ControllerBase
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;
        public AdvisoryTeacherController(SchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // ***** GET ***** //
        [HttpGet]
        public IActionResult GetAdvisoryTeachers()
        {
            GetTeachersQuery teachersQuery = new GetTeachersQuery(_context, _mapper);
            var result = teachersQuery.Handle();
            return Ok(result);
        }


        // ***** GET {id} ***** //
        [HttpGet("{id}")]
        public IActionResult GetAdvisoryTeacherDetail(int id)
        {
            GetTeacherDetailQuery query = new GetTeacherDetailQuery(_context, _mapper);
            query.AdvisoryId = id;
            GetTeacherDetailQueryValidator validator = new GetTeacherDetailQueryValidator();
            validator.ValidateAndThrow(query);
            var result = query.Handle();
            return Ok(result);
        }


        // ***** CREATE ***** //
        [HttpPost]
        public IActionResult AddTeacher([FromBody] CreateTeacherModel newTeacher)
        {
            CreateTeacherCommand command = new CreateTeacherCommand(_context, _mapper);
            command.Model = newTeacher;
            CreateTeacherCommandValidator validator = new CreateTeacherCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok("Rehber ogretmen basariyla eklendi!");
        }


        // ***** UPDATE ***** //
        [HttpPut("{id}")]
        public IActionResult UpdateTeacher(int id, [FromBody] UpdateTeacherModel updateTeacher)
        {

            UpdateTeacherCommand command = new UpdateTeacherCommand(_context);
            command.AdvisoryId = id;
            command.Model = updateTeacher;

            UpdateTeacherCommandValidator validator = new UpdateTeacherCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok("Rehber ogretmen basariyla guncellendi!");
        }


        // ***** DELETE ***** //
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DeleteTeacherCommand command = new DeleteTeacherCommand(_context);
            command.AdvisoryId = id;

            DeleteTeacherCommandValidator validator = new DeleteTeacherCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok("Rehber ogretmen basariyla silindi!");
        }
    }
}
