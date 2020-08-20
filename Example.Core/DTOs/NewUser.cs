using System.ComponentModel.DataAnnotations;

namespace Example.Core.DTOs
{
    public class NewUser
    {
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; } = default!;

        [Required(AllowEmptyStrings = false)]
        public char MiddleName { get; set; } = default!;

        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; } = default!;

        [Required(AllowEmptyStrings = false)]
        public string Phone { get; set; } = default!;

        [EmailAddress]
        [Required(AllowEmptyStrings = false)]
        public string EmailAddress { get; set; } = default!;
    }
}
