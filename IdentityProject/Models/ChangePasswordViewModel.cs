using System.ComponentModel.DataAnnotations;

namespace IdentityProject.Models
{
    public class ChangePasswordViewModel
    {
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
    }
}
