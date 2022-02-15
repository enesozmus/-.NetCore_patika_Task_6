using System.ComponentModel.DataAnnotations;
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations.Schema;
=======
>>>>>>> 059afec4f1586d874d6656d52a0ae5a59233c77e

namespace WebApi.Entities
{
    public class AdvisoryTeacher
    {
        [Key]
<<<<<<< HEAD
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
=======
>>>>>>> 059afec4f1586d874d6656d52a0ae5a59233c77e
        public int AdvisoryId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StudentId { get; set; }
    }
}
