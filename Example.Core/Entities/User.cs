using System;
using System.ComponentModel.DataAnnotations;

namespace Example.Core.Entities
{
    public class User
    {
        [Key] 
        public Guid Id { get; set; }

        public string FirstName { get; set; } = default!;

        public char MiddleName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public string EmailAddress { get; set; } = default!;

        public string Phone { get; set; } = default!;
    }
}
