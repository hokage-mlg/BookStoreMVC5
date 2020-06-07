using BookStore.Domain.Entities;
using System.Data.Entity;

namespace BookStore.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<DeliveryDetails> DeliveryDetails { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
    }
    public class UserDbInitializer : CreateDatabaseIfNotExists<EFDbContext>
    {
        protected override void Seed(EFDbContext context)
        {
            context.Roles.Add(new Role { RoleId = 1, Name = "admin" });
            context.Roles.Add(new Role { RoleId = 2, Name = "user" });
            context.Users.Add(new User
            {
                UserId = 1,
                Email = "somemail@gmail.com",
                Password = "123",
                Age = 20,
                RoleId = 1
            });
            base.Seed(context);
        }
    }
}
