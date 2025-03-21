using bookStore.DataAcess.Entities;
using Microsoft.EntityFrameworkCore;
namespace bookStore.DataAcess
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {
            
        }
        public DbSet<BookEntity> Book { get; set; }
    }
}
