using ECommerce.ViewModels;

namespace ECommerce.Services
{
    public interface IProductServices
    {
        Task<(List<ProductListViewModel> ProductList, AppResultStatus Result)> GetAllProducts();
        Task AddProduct(AddProductViewModel product);
        Task DeleteProduct(string protectedId);
        Task<UpdateProductViewModel> GetProductById(string productId);
        Task UpdateProduct(UpdateProductViewModel product);
        //Here we can add more services also
    }
}
