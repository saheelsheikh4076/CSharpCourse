using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace IdentityProject.Models
{
   
    public class LoginViewModel
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public Boolean Remember { get; set; }
    }
}
