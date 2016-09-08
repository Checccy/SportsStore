using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportsStore.Domain.Entities;

namespace SportsStore.Web.Areas.ProductArea.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public ProductPagingDTO ProductPagingDTO { get; set; }
        public string CurrentCategory { get; set; }
    }
}