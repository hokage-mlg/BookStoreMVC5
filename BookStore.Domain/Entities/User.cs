using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Domain.Entities
{
    [Table("Users")]
    public class User
    {
        [HiddenInput(DisplayValue = false)]
        [Key]
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
    }
}
