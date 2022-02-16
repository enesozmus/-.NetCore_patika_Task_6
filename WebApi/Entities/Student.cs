using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public int Number { get; set; }
        public AdvisoryTeacher AdvisoryTeacher { get; set; }                    // relations → one to one
        public List<Exam> Exam { get; set; }                                    // relations → one to many
        public ICollection<StudentCourse> StudentCourses { get; set; }          // relations → many to many
    }
}
