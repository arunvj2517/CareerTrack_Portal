using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMvcApp.Models
{
    public class Application
    {
        [Key]
        public string ApplicationId { get; set; } // PK

        public string Notes { get; set; }

        public string Status { get; set; }

        public string CompanyName { get; set; }

        public string PositionTitle { get; set; }

        public string JobDescription { get; set; }

        public DateTime ApplicationDate { get; set; }

        // FK
        [Required]
        public string StudentId { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }

        public ICollection<Interview> Interviews { get; set; }
    }
}
