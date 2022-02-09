using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
