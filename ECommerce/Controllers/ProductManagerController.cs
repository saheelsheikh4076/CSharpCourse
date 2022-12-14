using ECommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    /// <summary>
    /// This controller will be responsible to add delete update products
    /// </summary>
    public class ProductManagerController : Controller
    {
        public IActionResult Index()
        {
            List<ProductListViewModel> model = new List<ProductListViewModel>();
            //Get list from interface
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Pass this model to interface for adding in database
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string ProtectedId)
        {
            //Pass the id to interface for delete
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Update(string ProtectedId)
        {
            //Pass the id to interface and get the record for that id into a model
            //pass the model to view
            return View();//model)
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                //pass the model to interface for updation
                return RedirectToAction("index");
            }
            return View(model);
        }
    }
}
