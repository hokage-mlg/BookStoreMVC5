﻿using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BookStore.Domain.Entities
{
    public class DeliveryDetails
    {
        [HiddenInput(DisplayValue = false)]
        public int OrderId { get; set; }
        [Display(Name = "Фамилия, имя, отчество получателя")]
        [Required(ErrorMessage = "Пожалуйста, укажите Ф.И.О.")]
        public string FullName { get; set; }
        [Display(Name ="Почтовый индекс")]
        [Required(ErrorMessage = "Пожалуйста, укажите почтовый индекс")]
        public string Postcode { get; set; }
        [Display(Name="Страна")]
        [Required(ErrorMessage = "Пожалуйста, укажите страну")]
        public string Country { get; set; }
        [Display(Name = "Город")]
        [Required(ErrorMessage = "Пожалуйста, укажите город")]
        public string City { get; set; }
        [Display(Name = "Улица")]
        [Required(ErrorMessage = "Пожалуйста, укажите улицу")]
        public string Street { get; set; }
        [Display(Name = "Дом")]
        [Required(ErrorMessage = "Пожалуйста, укажите дом")]
        public string Building { get; set; }
        [Display(Name = "Номер квартиры")]
        [Required(ErrorMessage = "Пожалуйста, укажите номер квартиры")]
        public string ApartmentNum { get; set; }
        [Display(Name = "Подарочная упаковка")]
        public bool GiftWrap { get; set; }
    }
}
