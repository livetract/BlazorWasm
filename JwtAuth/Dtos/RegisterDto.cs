using System;

namespace JwtAuth.Dtos
{
    public class RegisterDto
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
        
        public DateTime RegTime { get; set; }

        public string CustomTag { get; set; }

        public string Email { get; set; }
    }
}