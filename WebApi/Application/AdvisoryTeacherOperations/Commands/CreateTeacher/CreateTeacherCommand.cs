using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AdvisoryTeacherOperations.Commands.CreateTeacher
{
    public class CreateTeacherCommand
    {
        public CreateTeacherModel Model { get; set; }
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;

        public CreateTeacherCommand(SchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var teacher = _context.AdvisoryTeachers.SingleOrDefault(x => x.FirstName == Model.FirstName && x.LastName == Model.LastName);
            if (teacher is not null)
                throw new InvalidOperationException("Eklemeye çaliştiginiz rehber ogretmen zaten mevcut!");
            teacher = _mapper.Map<AdvisoryTeacher>(Model);
            _context.AdvisoryTeachers.Add(teacher);
            _context.SaveChanges();
        }
    }

    public class CreateTeacherModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
