using System;

namespace JwtAuth.Entities
{
    public class IdentityUser
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public DateTime RegTime { get; set; }

        public string CustomTag { get; set; }

        public string Email { get; set; }
    }
}