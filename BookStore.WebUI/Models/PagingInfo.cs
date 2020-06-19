using System;

namespace BookStore.WebUI.Models
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages
        {
            get => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
        }
    }
}