using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMvcApp.Models
{
    public class Interview
    {
        [Key]
        public string InterviewId { get; set; }

        public string Notes { get; set; }

        public string Outcome { get; set; }

        public string Interviewer { get; set; }

        public DateTime InterviewDate { get; set; }

        public string InterviewType { get; set; }

        // FK
        [Required]
        public string ApplicationId { get; set; }

        [ForeignKey("ApplicationId")]
        public Application Application { get; set; }
    }
}
