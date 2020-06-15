using System.ComponentModel.DataAnnotations;

namespace BookStore.WebUI.Models
{
    public class RegisterViewModel
    {
        [Display(Name = "Логин")]
        [Required(ErrorMessage = "Пожалуйста, введите ваш E-mail")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Пожалуйста, введите корректный E-mail")]
        public string UserName { get; set; }
        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Пожалуйста, введите ваш пароль")]
        public string Password { get; set; }
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Пожалуйста, введите ваше имя")]
        public string Name { get; set; }
        [Display(Name = "Возраст")]
        [Required(ErrorMessage = "Пожалуйста, введите ваш возраст")]
        [RegularExpression(@"^(?:1[01][0-9]|120|1[4-9]|[2-9][0-9])$",
                            ErrorMessage = "Пожалуйста, введите корректный возраст. Вам должно быть больше 14 лет.")]
        public int Age { get; set; }
    }
}