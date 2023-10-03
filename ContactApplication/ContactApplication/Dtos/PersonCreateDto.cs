using System.ComponentModel.DataAnnotations;

namespace ContactApplication.Dtos
{
    public class PersonCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string CompanyName { get; set; }
    }
}
