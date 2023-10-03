using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ContactApplication.Models
{
    public class ContactInformation
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Person")]
        public Guid PersonId { get; set; }
        [AllowNull]
        public string PhoneNumber { get; set; }
        [AllowNull]
        public string Email { get; set; }
        [AllowNull]
        public string Location { get; set; }

        [AllowNull]
        public virtual Person Person { get; set; }
    }
}
