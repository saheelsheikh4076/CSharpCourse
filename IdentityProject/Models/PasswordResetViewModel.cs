using Microsoft.Build.Framework;

namespace IdentityProject.Models
{
    public class PasswordResetViewModel
    {
        [Required]
        public string Password { get; set; }
        public string UserId { get; set; }
        public string Token { get; set; }
    }
}
