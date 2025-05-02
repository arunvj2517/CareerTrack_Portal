using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Metadata;

namespace MyMvcApp.Models
{
    public class Student
    {
        [Key]
        public string StudentId { get; set; } // PK

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public string Major { get; set; }

        public string PasswordHash { get; set; }

        public int GraduationYear { get; set; }

        // Relationships
        public ICollection<Application> Applications { get; set; }
        public ICollection<Document> Documents { get; set; }
    }
}
