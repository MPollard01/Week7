using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookstoreWebApp.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [DisplayName("Street Address")]
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        [DisplayName("Post Code")]
        public string? PostalCode { get; set; }
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone Number")]
        public long? PhoneNumber { get; set; }
    }
}
