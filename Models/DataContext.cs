using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ProducManagementWebApi.Models

{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProductManagement;Integrated Security=True");
        }
        
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Product> Products { get; set;}
    }
}
