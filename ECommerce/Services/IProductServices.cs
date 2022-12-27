using ECommerce.ViewModels;

namespace ECommerce.Services
{
    public interface IProductServices
    {
        Task<(List<ProductListViewModel> ProductList, AppResultStatus Result)> GetAllProducts();
        Task<AppResultStatus> AddProduct(AddProductViewModel product);
        Task<AppResultStatus> DeleteProduct(string protectedId);
        Task<(UpdateProductViewModel Product, AppResultStatus Result)> GetProductById(string productId);
        Task<AppResultStatus> UpdateProduct(UpdateProductViewModel product);
        //Here we can add more services also
    }
}
