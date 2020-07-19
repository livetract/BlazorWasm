using System;

namespace JwtAuth.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public DateTime RegTime { get; set; }

        public string CustomTag { get; set; }

        public string Email { get; set; }
    }
}