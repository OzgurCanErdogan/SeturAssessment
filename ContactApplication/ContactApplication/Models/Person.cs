using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ContactApplication.Models
{
    public class Person
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [AllowNull]
        public string Name { get; set; }
        [Required]
        [AllowNull]
        public string Surname { get; set; }
        [Required]
        [AllowNull]
        public string CompanyName { get; set; }
    }
}