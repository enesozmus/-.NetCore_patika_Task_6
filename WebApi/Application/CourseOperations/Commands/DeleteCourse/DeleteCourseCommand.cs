using WebApi.DBOperations;

namespace WebApi.Application.CourseOperations.Commands.DeleteCourse
{
    public class DeleteCourseCommand
    {
        private readonly SchoolDbContext _context;
        public int courseId { get; set; }
        public DeleteCourseCommand(SchoolDbContext context)
        {
            _context = context;
        }

        public bool Handle()
        {
            var course = _context.Courses
                                       .SingleOrDefault(a => a.Id == courseId);
            if (course == null)
                throw new InvalidOperationException("Silmek istediginiz kurs/ders bulunamadi!");

            _context.Courses.Remove(course);
            int result = _context.SaveChanges();
            return Convert.ToBoolean(result);
        }
    }
}
