using System.ComponentModel.DataAnnotations;

namespace BookStore.WebUI.Models
{
    public class RegisterViewModel
    {
        [Display(Name = "Логин")]
        [Required(ErrorMessage = "Пожалуйста, введите ваш E-mail")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
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