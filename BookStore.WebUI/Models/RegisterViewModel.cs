using System.ComponentModel.DataAnnotations;

namespace BookStore.WebUI.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int Age { get; set; }
    }
}