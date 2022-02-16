using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.CourseOperations.Queries.GetCourseDetail
{
    public class GetCourseDetailQuery
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;
        public int courseId { get; set; }
        public GetCourseDetailQuery(SchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public CourseDetailViewModel Handle()
        {
            var course = _context.Courses
                                    .SingleOrDefault(x => x.CourseId == courseId);

            if (course is null)
                throw new InvalidOperationException("Aradıgınız kurs/ders bulunamadi!");

            CourseDetailViewModel vm = _mapper.Map<CourseDetailViewModel>(course);
            return vm;
        }
    }

    public class CourseDetailViewModel
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
    }
}
