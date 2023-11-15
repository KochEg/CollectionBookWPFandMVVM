using CollectionBookWPF.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace CollectionBookWPF.Models.Data
{
    class ApplicationContext : DbContext
    {
        public DbSet<Book> Books { get; set; } 

        public ApplicationContext() 
        {
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CollectionBook;Trusted_Connection=True");
        }
    }
}
