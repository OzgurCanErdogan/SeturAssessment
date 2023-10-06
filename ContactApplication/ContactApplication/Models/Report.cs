using System.ComponentModel.DataAnnotations;

namespace ContactApplication.Models
{
    public class Report
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime RequestDateTime { get; set; }
        [Required]
        public ReportStatus Status { get; set; }

        public ICollection<ReportDetails> ReportDetails { get; set; }
    }

    public enum ReportStatus
    {
        InProgress,
        Created
    }
}
