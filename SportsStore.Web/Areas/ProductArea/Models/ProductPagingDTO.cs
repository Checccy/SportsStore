using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.Web.Areas.ProductArea.Models
{
    public class ProductPagingDTO
    {
        public int TotalItems { get; set; }
        public int ItemPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemPerPage);
    }
}