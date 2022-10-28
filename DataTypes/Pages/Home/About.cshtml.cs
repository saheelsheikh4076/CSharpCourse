using MainProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MainProject.Pages.Home
{
    public class AboutModel : PageModel
    {
        private readonly NewTestClass test1;
        public AboutModel(NewTestClass test)
        {
            test1 = test;
        }
        public void OnGet()
        {
        }
    }
}
