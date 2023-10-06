using ReportApplication.Models;
using System.ComponentModel.DataAnnotations;

namespace ReportApplication.Dtos
{
    public class ReportsReadDto
    {
        public Guid Id { get; set; }
        public DateTime RequestDateTime { get; set; }
        public ReportStatus Status { get; set; }
    }
}
