using System.ComponentModel.DataAnnotations;

namespace ContactApplication.Dtos
{
    public class ContactInformationCreateDto
    {
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Location { get; set; }
    }
}
