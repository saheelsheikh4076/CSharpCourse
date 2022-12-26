using AutoMapper;
using ECommerce.Data;
using ECommerce.ViewModels;

namespace ECommerce.Models
{
    public class AppMapper:Profile
    {
        public AppMapper()
        {
            CreateMap<Product, AddProductViewModel>().ReverseMap();
            CreateMap<Product, ProductListViewModel>().ReverseMap();
            //CreateMap<List<Product>, List<AddProductViewModel>>().ReverseMap();
        }
    }
}
