

namespace ContactApplication.Dtos
{
    public class ContactInformationReadDto
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
    }
}
