using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.StudentOperations.Commands.CreateStudent
{
    public class CreateStudentCommand
    {
        public CreateStudentModel Model { get; set; }
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;

        public CreateStudentCommand(SchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var student = _context.Students
                                    .SingleOrDefault(x => x.FirstName == Model.FirstName && x.Number == Model.Number);
            if (student is not null)
                throw new InvalidOperationException("Eklemeye çaliştiginiz ogrenci zaten mevcut!");
            
            student = _mapper.Map<Student>(Model);
            _context.Students.Add(student);
            _context.SaveChanges();
        }
    }

    public class CreateStudentModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public int Number { get; set; }
    }
}
