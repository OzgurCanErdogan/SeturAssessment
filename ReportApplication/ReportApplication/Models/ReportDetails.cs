using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReportApplication.Models
{
    public class ReportDetails
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Report")]
        public Guid ReportId { get; set; }

        public byte[] ReportByte { get; set; }

        public Report Report { get; set; }
    }
}
