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
        [Display(Name = "Логин (E-mail)")]
        [Required(ErrorMessage = "Пожалуйста, введите ваш E-mail")]
        public string Email { get; set; }
        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Пожалуйста, введите ваш пароль")]
        public string Password { get; set; }
        [Display(Name = "Возраст")]
        [Required(ErrorMessage = "Пожалуйста, введите ваш возраст")]
        public int Age { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int RoleId { get; set; }
        [HiddenInput(DisplayValue = false)]
        public Role Role { get; set; }
    }
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
    }
}
