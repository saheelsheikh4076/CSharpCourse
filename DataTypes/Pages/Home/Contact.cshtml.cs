using MainProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MainProject.Pages.Home
{
    public class ContactModel : PageModel
    {
        private readonly NewTestClass test1;
        public ContactModel(NewTestClass test)
        {
            test1 = test;
        }
        public void OnGet()
        {
        }
    }
}
