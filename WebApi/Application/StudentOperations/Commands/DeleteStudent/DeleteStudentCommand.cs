using WebApi.DBOperations;

namespace WebApi.Application.StudentOperations.Commands.DeleteStudent
{
    public class DeleteStudentCommand
    {
        private readonly SchoolDbContext _context;
        public int StudentId { get; set; }
        public DeleteStudentCommand(SchoolDbContext context)
        {
            _context = context;
        }

        public bool Handle()
        {
            var student = _context.Students.SingleOrDefault(a => a.StudentId == StudentId);
            if (student == null)
                throw new InvalidOperationException("Silmek istediginiz ogrenci bulunamadi!");

            // Other Start
            var advisory = _context.AdvisoryTeachers.Any(a => a.StudentId == StudentId);
            if(advisory != null)
                throw new InvalidOperationException("Once rehber ogretmen silinmelidir!");
            //var books = _context.Books.Any(x => x.StudentId == Id);
            //if (!books)
            //    throw new InvalidOperationException("Önce kitaplar silinmelidir!");
            // Other End
            _context.Students.Remove(student);
            int result = _context.SaveChanges();
            return Convert.ToBoolean(result);
        }
    }
}
