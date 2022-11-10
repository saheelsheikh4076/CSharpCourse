using Microsoft.AspNetCore.Mvc;
using MVCProject.ViewModels;

namespace MVCProject.Controllers
{
    public class TestClass
    {
        public int Id { get; set; }
    }
    public class AccountController : Controller
    {
        public IActionResult Test5()
        {

            TempData["Key1"] = 10;
            TempData["Key2"] = 1.0f;
            TempData["Key3"] = true;

            TestClass t = new TestClass(); t.Id = 100;

            List<TestClass> tList = new List<TestClass>()
            {
                t,t,t,t,t
            };

            TempData["TestClass"] = tList;

#nullable disable
            //+++++++++++++++++++++++++++
            var intValue1 = (int)TempData["Key1"];
           // var intValue = Convert.ToInt32(TempData["Key1"].ToString());
            var floatValue = (float)TempData["Key2"];
            var boolValue = (bool)TempData["Key3"];
            var testClass = (List<TestClass>)TempData["TestClass"];
#nullable restore
            return View();
        }
        public IActionResult Test1()
        {
            TempData["Heading"] = "This heading is coming from backend";
            return View();
        }
        public IActionResult Test2()
        {
            var data = TempData["Heading"].ToString();
            TempData.Keep("Heading");
            return View();
        }
        public IActionResult Test3()
        {
            var data = TempData["Heading"].ToString();
            return View();
        }
        public IActionResult Test4()
        {
            var data = TempData.Peek("Heading").ToString();//Fetch + Keep
            return View();
        }
        //Flow1 Test1 ->2 -> 3->4
        //Flow2 Test1->4 ->3
        [HttpGet]
        public IActionResult Index()
        {
            TempData["Heading"] = "This heading is coming from backend";
            if (TempData.ContainsKey("Heading"))
            {
                var data = TempData["Heading"].ToString();
                TempData.Keep("Heading");
                data = TempData["Heading"].ToString();

                data = TempData["Heading"].ToString();

                data = TempData["Heading"].ToString();

            }


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
                new Book{Title = ".net", Auth = "Microsoft"},
                new Book{Title = "c#", Auth="Irfan sir"},
                new Book{Title = "computer", Auth ="Arshad"},
                new Book{Title = "Electronics", Auth = "Tauhid"}
            };
           // model.Books = new List<Book>();

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public IActionResult Index(string Title, string Author)
        public IActionResult Index(AccountIndexViewModel model)
        {
            if (ModelState.IsValid && model.Book.File.ContentType== "image/jpeg")
            {

            }
            return View();
        }
    }
}
