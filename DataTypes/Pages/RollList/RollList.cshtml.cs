using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;

namespace MainProject.Pages.RollList
{
    public class RollListModel : PageModel
    {
        private readonly IRollList rollList;

        public RollListModel(IRollList rollList)
        {
            this.rollList = rollList;
        }
        [BindProperty]
        public int RollNo { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            rollList.Add(RollNo);
            ModelState.Clear();
        }
    }
}
