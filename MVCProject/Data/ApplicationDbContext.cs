using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MVCProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<StudentTable> StudentTable { get; set; }
        public DbSet<GenderTable> GenderTable { get; set; }
    }
    public class StudentTable
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        public int? Age { get; set; }
        public int? Gender { get; set; }
    }
    public class GenderTable
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(6)]
        public string Gender { get; set; }
    }
}
