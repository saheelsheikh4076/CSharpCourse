using MainProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MainProject.Pages.Home
{
    public class ProfileModel : PageModel
    {
        private readonly NewTestClass test1;
        public ProfileModel(NewTestClass test)
        {
            test1 = test;
        }
        public void OnGet()
        {
        }
    }
}
