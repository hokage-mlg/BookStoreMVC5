using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStore.Domain.Entities;

namespace BookStore.WebUI.Models
{
    public class UserIndexViewModel
    {
        public User User { get; set; }
        public string ReturnUrl { get; set; }
    }
}