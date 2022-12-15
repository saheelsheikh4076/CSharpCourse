namespace ECommerce.ViewModels
{
    public class UpdateProductViewModel
    {
        public int Id { get; set; }
        public string ProtectedId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
    public class ProductListViewModel
    {
        public int Id { get; set; }
        public string ProtectedId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
    public class AddProductViewModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
