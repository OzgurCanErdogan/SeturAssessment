namespace ReportApplication.Dtos
{
    public class PersonDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CompanyName { get; set; }
        public List<ContactInformationDto> ContactInformation { get; set; }
    }
}
