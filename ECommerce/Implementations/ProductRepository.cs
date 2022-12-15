using ECommerce.Services;
using ECommerce.ViewModels;

namespace ECommerce.Implementations
{
    public class ProductRepository : IProductServices
    {
        public Task AddProduct(AddProductViewModel product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProduct(string protectedId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductListViewModel>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<UpdateProductViewModel> GetProductById(string productId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProduct(UpdateProductViewModel product)
        {
            throw new NotImplementedException();
        }
    }
}
