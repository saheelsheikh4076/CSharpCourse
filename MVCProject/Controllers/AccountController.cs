using Microsoft.AspNetCore.Mvc;
using MVCProject.ViewModels;

namespace MVCProject.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            //the word 'sentence' in the following instruction is called key and value is written after =
            ViewData["sentence"] = "Front end of Account Index page coming from backend";
            //the word 'myname' is key and "Irfan sir" is value
            ViewBag.myname = "Irfan sir";
            int i = 10;
            string s = "abcd";
            //object o1 = 10;
            //object o2 = "abcd";
            //dynamic d1 = "abcd";
            AccountIndexViewModel model = new AccountIndexViewModel();
            model.Books = new List<Book>
            {
                new Book{Title = ".net", Author = "Microsoft"},
                new Book{Title = "c#", Author="Irfan sir"},
                new Book{Title = "computer", Author ="Arshad"},
                new Book{Title = "Electronics", Author = "Tauhid"}
            };
            
            return View(model);
        }
    }
}
