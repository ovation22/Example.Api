using System;

namespace Example.Core.DTOs
{
    public class UserResult
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = default!;

        public string Phone { get; set; } = default!;

        public string EmailAddress { get; set; } = default!;
    }
}
