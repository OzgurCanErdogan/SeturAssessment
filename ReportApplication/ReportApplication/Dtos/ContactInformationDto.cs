using System.Diagnostics.CodeAnalysis;

namespace ReportApplication.Dtos
{
    public class ContactInformationDto
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
    }
}
