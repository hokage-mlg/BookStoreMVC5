using System.Collections.Generic;
using BookStore.Domain.Entities;

namespace BookStore.Domain.Abstract
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get; }
        void SaveUser(User user);
        void ChangePassword(User user, string newPass);
        User GiveRole(int userId, int roleId);
    }
}
