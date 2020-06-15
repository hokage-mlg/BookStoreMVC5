using System.ComponentModel.DataAnnotations;

namespace BookStore.WebUI.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Логин")]
        [Required(ErrorMessage = "Пожалуйста, введите ваш E-mail")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Пожалуйста, введите корректный E-mail")]
        public string UserName { get; set; }
        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Пожалуйста, введите ваш пароль")]
        public string Password { get; set; }
    }
}