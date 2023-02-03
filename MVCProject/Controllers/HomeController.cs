using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.ViewModels;
using System.Diagnostics;

namespace MVCProject.Controllers
{
    /// <summary>
    /// Name of Controller - Name should be appended with 
    /// the word "Controller" without spelling mistake 
    /// and with Upper camel case
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //Following is called Index GET Action
        public IActionResult Index()
        {
            //This function/Method/Action is responsible 
            //to generate frontend view
            return View();//View Function returns ViewResult i.e. Frond end HTML view
            //It combines Layout and its view and generates complete
            //html page which is rendered to client side
        }
        public IActionResult ApiTest()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult TestPage()
        {
            var model = new BannerPartialViewModel
            {
                Name = "Irfan from Controller",
                Age = 40,
                Address = "Nagpur",
                Mobile = "3453453"
            };
            return View(model);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}