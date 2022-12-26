using AutoMapper;
using ECommerce.Data;
using ECommerce.Models;
using ECommerce.Services;
using ECommerce.ViewModels;
using Elfie.Serialization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Implementations
{
    public class ProductRepository : IProductServices
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IDataProtector protector;

        public ProductRepository(AppDbContext dbContext,IMapper mapper,
            IDataProtectionProvider dataProtectionProvider,
            AppKeys keys)
        {
            this.protector = dataProtectionProvider.CreateProtector(keys.DataProtectionKey);
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task AddProduct(AddProductViewModel product)
        {
            var newProduct = mapper.Map<Product>(product);

            //newProduct.Name = product.Name;
            //newProduct.Description = product.Description;
            //newProduct.Price = product.Price;
            await dbContext.Product.AddAsync(newProduct);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteProduct(string protectedId)
        {
            var id = Convert.ToInt32(protector.Unprotect(protectedId));
            var product = await dbContext.Product.FindAsync(id);
            if(product != null)
            {
                dbContext.Product.Remove(product);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<(List<ProductListViewModel> ProductList, AppResultStatus Result)> GetAllProducts()
        {
            AppResultStatus result = new AppResultStatus();
            result.ErrorCode = 1000;
            //Mapping Condition is that all the properties in destination must get value from source
            List<ProductListViewModel> productList = new();
            try
            {
                var products = await dbContext.Product.AsNoTracking().ToListAsync();
                //productList = mapper.Map<List<ProductListViewModel>>(products);
                //mapper.Map(products, productList,typeof(List<Product>),typeof(List<ProductListViewModel>));
                foreach (var product in products)
                {
                    //productList.Add(mapper.Map<ProductListViewModel>(product));
                    productList.Add(new ProductListViewModel
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price,
                        ProtectedId = protector.Protect(product.Id.ToString())
                    });
                }
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return (productList,result);
        }

        public async Task<UpdateProductViewModel> GetProductById(string productId)
        {
            UpdateProductViewModel product = new UpdateProductViewModel();
            var id = Convert.ToInt32(protector.Unprotect(productId));
            var _Product = await dbContext.Product.Where(s=>s.Id == id).AsNoTracking().FirstOrDefaultAsync();
            if(_Product != null)
            {
                product.Id = _Product.Id;
                product.Name = _Product.Name;
                product.Description = _Product.Description;
                product.Price = _Product.Price;
                //product = mapper.Map<UpdateProductViewModel>(_Product);
                product.ProtectedId = protector.Protect(_Product.Id.ToString());
            }
            return product;
        }

        public async Task UpdateProduct(UpdateProductViewModel product)
        {
            var id = Convert.ToInt32(protector.Unprotect(product.ProtectedId));

            var _Product = await dbContext.Product.FindAsync(id);
            if(_Product != null)
            {
                _Product.Name = product.Name;
                _Product.Description = product.Description;
                _Product.Price = product.Price;
                await dbContext.SaveChangesAsync();
                //we can verify using sql profiler that ef sends only the changed property
            }
        }
    }
}
