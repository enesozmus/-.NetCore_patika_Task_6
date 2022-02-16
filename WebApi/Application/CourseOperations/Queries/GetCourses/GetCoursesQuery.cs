using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.CourseOperations.Queries.GetCourses
{
    public class GetCoursesQuery
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;
        public int courseId { get; set; }
        public GetCoursesQuery(SchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<CoursesViewModel> Handle()
        {
            var courseList = _context.Courses
                                    .OrderBy(s => s.CourseId)
                                    .ToList<Course>();

            List<CoursesViewModel> vm = _mapper.Map<List<CoursesViewModel>>(courseList);
            return vm;
        }
    }

    public class CoursesViewModel
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
    }
}