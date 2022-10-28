using MainProject.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MainProject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly NewTestClass test1;
        public IndexModel(NewTestClass test)
        {
            test1 = test;
        }
        public void OnGet()
        {
            test1.Id = test1.Id == 0 ? 10 : test1.Id;
            //Front end of this page lies here i.e. in this scope
        }
    }
    
    
}
