using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.CourseOperations.Commands.CreateCourse;
using WebApi.Application.CourseOperations.Commands.DeleteCourse;
using WebApi.Application.CourseOperations.Commands.UpdateCourse;
using WebApi.Application.CourseOperations.Queries.GetCourseDetail;
using WebApi.Application.CourseOperations.Queries.GetCourses;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;
        public CourseController(SchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // ***** GET ***** //
        [HttpGet]
        public IActionResult GetCourses()
        {
            GetCoursesQuery coursesQuery = new GetCoursesQuery(_context, _mapper);
            var result = coursesQuery.Handle();
            
            return Ok(result);
        }


        // ***** GET {id} ***** //
        [HttpGet("{id}")]
        public IActionResult GetCourseDetail(int id)
        {
            GetCourseDetailQuery query = new GetCourseDetailQuery(_context, _mapper);
            query.courseId = id;
            GetCourseDetailQueryValidator validator = new GetCourseDetailQueryValidator();
            validator.ValidateAndThrow(query);
            
            var result = query.Handle();
            return Ok(result);
        }


        // ***** CREATE ***** //
        [HttpPost]
        public IActionResult AddCourse([FromBody] CreateCourseModel newCourse)
        {
            CreateCourseCommand command = new CreateCourseCommand(_context, _mapper);
            command.Model = newCourse;
            CreateCourseCommandValidator validator = new CreateCourseCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok("Kurs/ders basariyla eklendi!");
        }


        // ***** UPDATE ***** //
        [HttpPut("{id}")]
        public IActionResult UpdateCourse(int id, [FromBody] UpdateCourseModel updateCourse)
        {

            UpdateCourseCommand command = new UpdateCourseCommand(_context);
            command.Id = id;
            command.Model = updateCourse;

            UpdateCourseCommandValidator validator = new UpdateCourseCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok("Kurs/ders basariyla guncellendi!");
        }


        // ***** DELETE ***** //
        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            DeleteCourseCommand command = new DeleteCourseCommand(_context);
            command.courseId = id;
            
            DeleteCourseCommandValidator validator = new DeleteCourseCommandValidator();
           
            validator.ValidateAndThrow(command);
            var result = command.Handle();
            
            if (result)
                return Ok("Kurs/ders basariyla silindi!");
            return BadRequest();
        }
    }
}
