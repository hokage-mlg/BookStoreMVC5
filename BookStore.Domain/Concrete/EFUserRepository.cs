using System.Collections.Generic;
using BookStore.Domain.Abstract;
using BookStore.Domain.Entities;

namespace BookStore.Domain.Concrete
{
    public class EFUserRepository : IUserRepository
    {
        EFDbContext context = new EFDbContext();
        public IEnumerable<User> Users => context.Users;
        public void SaveUser(User user)
        {
            var dbEntry = context.Users.Find(user.UserId);
            if (dbEntry != null)
            {
                dbEntry.Email = user.Email;
                dbEntry.Name = user.Name;
                dbEntry.Age = user.Age;
            }
            context.SaveChanges();
        }
        public void ChangePassword(User user, string newPass)
        {
            var dbEntry = context.Users.Find(user.UserId);
            if (dbEntry != null && newPass != "")
            {
                dbEntry.Password = newPass;
                context.SaveChanges();
            }
        }
        public User GiveRole(int userId, int roleId)
        {
            var dbEntry = context.Users.Find(userId);
            if (dbEntry != null)
            {
                dbEntry.RoleId = roleId;
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
