using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.CourseOperations.Commands.CreateCourse
{
    public class CreateCourseCommand
    {
        public CreateCourseModel Model { get; set; }
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;

        public CreateCourseCommand(SchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var course = _context.Courses
                                    .SingleOrDefault(x => x.Id == Model.Id && x.Name == Model.Name);
            if (course is not null)
                throw new InvalidOperationException("Eklemeye çaliştiginiz kurs/ders zaten mevcut!");

            course = _mapper.Map<Course>(Model);
            _context.Courses.Add(course);
            _context.SaveChanges();
        }
    }

    public class CreateCourseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
