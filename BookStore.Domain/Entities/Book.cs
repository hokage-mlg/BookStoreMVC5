using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BookStore.Domain.Entities
{
    public class Book
    {
        [HiddenInput(DisplayValue = false)]
        public int BookId { get; set; }
        [Display(Name = "Название")]
        [Required(ErrorMessage = "Пожалуйста, введите название книги")]
        public string Title { get; set; }
        [Display(Name = "Автор")]
        [Required(ErrorMessage = "Пожалуйста, введите автора книги")]
        public string Author { get; set; }
        [Display(Name = "Жанр")]
        [Required(ErrorMessage = "Пожалуйста, введите жанр книги")]
        public string Genre { get; set; }
        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Пожалуйста, введите описание книги")]
        public string Description { get; set; }
        [Display(Name = "Цена")]
        [Required]
        [Range(0.01, double.MaxValue,
        ErrorMessage = "Пожалуйста, введите положительное значение для цены")]
        public decimal Price { get; set; }
        [Display(Name = "Количество")]
        [Required]
        [Range(0, int.MaxValue,
        ErrorMessage = "Пожалуйста, введите положительное значение для количества")]
        public int Quantity { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}