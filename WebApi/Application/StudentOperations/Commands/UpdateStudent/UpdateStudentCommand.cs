using WebApi.DBOperations;

namespace WebApi.Application.StudentOperations.Commands.UpdateStudent
{
    public class UpdateStudentCommand
    {
        public int StudentId { get; set; }
        public UpdateStudentModel Model { get; set; }
        private readonly SchoolDbContext _context;
        public UpdateStudentCommand(SchoolDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var student = _context.Students.SingleOrDefault(x => x.StudentId == StudentId);

            if (student is null)
                throw new InvalidOperationException("Guncellemeye calistiginiz ogrenci bulunamadi!");

            student.FirstName = Model.FirstName != default ? Model.FirstName : student.FirstName;
            student.LastName = Model.LastName != default ? Model.LastName : student.LastName;
            student.Birthday = Model.Birthday != default ? Model.Birthday : student.Birthday;
            student.Number = Model.Number != default ? Model.Number : student.Number;
            _context.SaveChanges();
        }
    }

    public class UpdateStudentModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public int Number { get; set; }
    }
}
