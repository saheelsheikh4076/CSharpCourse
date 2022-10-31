using MainProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;

namespace MainProject.Pages.Home
{
    public class ProfileModel : PageModel
    {
        private readonly IRollList rollList;

        [BindProperty]
        public int RollNo { get; set; }
        public ProfileModel(IRollList rollList)
        {
            this.rollList = rollList;
        }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            rollList.Delete(RollNo);
        }
    }
}
