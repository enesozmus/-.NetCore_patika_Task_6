using WebApi.DBOperations;

namespace WebApi.Application.AdvisoryTeacherOperations.Commands.DeleteTeacher
{
    public class DeleteTeacherCommand
    {
        private readonly SchoolDbContext _context;
        public int AdvisoryId { get; set; }
        public DeleteTeacherCommand(SchoolDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var teacher = _context.AdvisoryTeachers.SingleOrDefault(x => x.AdvisoryId == AdvisoryId);

            if (teacher is null)
                throw new InvalidOperationException("Silmek istediginiz rehber ogretmen bulunamadi!");

            _context.AdvisoryTeachers.Remove(teacher);
            _context.SaveChanges();
        }
    }
}
