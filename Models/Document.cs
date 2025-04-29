using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMvcApp.Models
{
    public class Document
    {
        [Key]
        public string DocumentId { get; set; }

        public string FileName { get; set; }

        public bool IsShared { get; set; }

        public DateTime UploadDate { get; set; }

        public string DocumentType { get; set; }

        // FK
        [Required]
        public string StudentId { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }
    }
}
