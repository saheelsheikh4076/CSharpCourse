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
            var result = await productServices.GetAllProducts().ConfigureAwait(false);
            if(result.Result.IsSuccess == false)
            {
                return View("Error", result.Result);
            }
            return View(result.ProductList);
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
                var result = await productServices.AddProduct(model).ConfigureAwait(false);
                if (!result.IsSuccess)
                {
                    return View("Error", result);
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string ProtectedId)
        {
            var result = await productServices.DeleteProduct(ProtectedId).ConfigureAwait(false);
            if (!result.IsSuccess)
            {
                return View("Error", result);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Update(string ProtectedId)
        {
            var model = await productServices.GetProductById(ProtectedId).ConfigureAwait(false);
            if (!model.Result.IsSuccess)
            {
                return View("Error", model.Result);
            }
            return View(model.Product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await productServices.UpdateProduct(model).ConfigureAwait(false);
                if (!result.IsSuccess)
                {
                    return View("Error", result);
                }
                return RedirectToAction("index");
            }
            return View(model);
        }
    }
}
