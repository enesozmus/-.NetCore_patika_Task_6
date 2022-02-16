using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Exam
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExamId { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public int StudentId { get; set; }
    }
}