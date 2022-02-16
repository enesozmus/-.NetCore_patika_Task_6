using WebApi.DBOperations;

namespace WebApi.Application.CourseOperations.Commands.UpdateCourse
{
    public class UpdateCourseCommand
    {
        public int Id { get; set; }
        public UpdateCourseModel Model { get; set; }
        private readonly SchoolDbContext _context;
        public UpdateCourseCommand(SchoolDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var course = _context.Courses
                                    .SingleOrDefault(x => x.CourseId == Id);

            if (course is null)
                throw new InvalidOperationException("Guncellemeye calistiginiz kurs/ders bulunamadi!");

            course.Name = Model.Name != default ? Model.Name : course.Name;
            _context.SaveChanges();
        }
    }
    public class UpdateCourseModel
    {
        public string Name { get; set; }
    }
}