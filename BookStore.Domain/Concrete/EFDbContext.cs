using BookStore.Domain.Entities;
using System.Data.Entity;

namespace BookStore.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }
}
