using Microsoft.AspNetCore.Mvc;
using MVCProject.ViewModels;
using Services;

namespace MVCProject.ViewComponents
{
    public class BannerViewComponent: ViewComponent
    {
        private readonly IRollList rollList;

        public BannerViewComponent(IRollList rollList)
        {
            this.rollList = rollList;
        }
        //public IViewComponentResult Invoke(string Name, int Age, string Address, string Mobile)
        public IViewComponentResult Invoke(BannerPartialViewModel data)
        {
            List<int> list = rollList.GetAll();
            return View(list);
        }
    }
}
