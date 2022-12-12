using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<Particular> Particular { get; set; }
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        
    }
    public class Cart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
    public class Invoice
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string TxnId { get; set; }
        public string RefId { get; set; }
    }
    public class Particular
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public double Price { get; set; }
    }
}
