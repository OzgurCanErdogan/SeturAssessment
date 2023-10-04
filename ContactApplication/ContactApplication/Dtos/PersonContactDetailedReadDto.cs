using ContactApplication.Models;

namespace ContactApplication.Dtos
{
    public class PersonContactDetailedReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CompanyName { get; set; }
        public List<ContactInformationReadDto> ContactInformation { get; set; }
    }
}
