using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.Application.AdvisoryTeacherOperations.Commands.UpdateTeacher
{
    public class UpdateTeacherCommand
    {
        public int AdvisoryId { get; set; }
        public UpdateTeacherModel Model { get; set; }
        private readonly SchoolDbContext _context;
        public UpdateTeacherCommand(SchoolDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var teacher = _context.AdvisoryTeachers
                                            .SingleOrDefault(x => x.AdvisoryId == AdvisoryId);

            if (teacher is null)
                throw new InvalidOperationException("Guncellemeye calistiginiz rehber ogretmen bulunamadi!");

            teacher.FirstName = Model.FirstName != default ? Model.FirstName : teacher.FirstName;
            teacher.LastName = Model.LastName != default ? Model.LastName : teacher.LastName;

            _context.SaveChanges();
        }
    }

    public class UpdateTeacherModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
