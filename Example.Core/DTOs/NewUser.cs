using System.ComponentModel.DataAnnotations;

namespace Example.Core.DTOs
{
    public class NewUser
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Phone { get; set; }

        [Required]
        [EmailAddress]
        public string? EmailAddress { get; set; }
    }
}
