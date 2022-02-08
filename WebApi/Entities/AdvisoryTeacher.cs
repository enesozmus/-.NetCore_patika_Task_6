using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class AdvisoryTeacher
    {
        [Key]
        public int AdvisoryId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StudentId { get; set; }
    }
}
