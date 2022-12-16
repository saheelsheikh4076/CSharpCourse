using ECommerce.Services;
using ECommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    /// <summary>
    /// This controller will be responsible to add delete update products
    /// </summary>
    public class ProductManagerController : Controller
    {
        private readonly IProductServices productServices;

        public ProductManagerController(IProductServices productServices)
        {
            this.productServices = productServices;
        }
        public async Task<IActionResult> Index()
        {
            var model = await productServices.GetAllProducts().ConfigureAwait(false);
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
                await productServices.AddProduct(model).ConfigureAwait(false);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string ProtectedId)
        {
            await productServices.DeleteProduct(ProtectedId).ConfigureAwait(false);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Update(string ProtectedId)
        {
            var model = await productServices.GetProductById(ProtectedId).ConfigureAwait(false);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                await productServices.UpdateProduct(model).ConfigureAwait(false);
                return RedirectToAction("index");
            }
            return View(model);
        }
    }
}
