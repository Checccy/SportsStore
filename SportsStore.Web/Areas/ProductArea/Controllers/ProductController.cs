using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstruct;
using SportsStore.Domain.Entities;
using SportsStore.Web.Areas.ProductArea.Models;

namespace SportsStore.Web.Areas.ProductArea.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository productRepository)
        {
            _repository = productRepository;
        }
        private int pagesize = 3;
        public ActionResult Index(string category,int page = 1)
        {
            ProductListViewModel viewModel = new ProductListViewModel
            {
                Products = _repository.Products
                    .Where(p=> category == null||p.Category== category)
                    .OrderBy(p => p.ProductGuid)
                    .Skip((page - 1) * pagesize)
                    .Take(pagesize),
                ProductPagingDTO = new ProductPagingDTO
                {
                    CurrentPage = page,
                    ItemPerPage = pagesize,
                    TotalItems = category==null?_repository.Products.Count():_repository.Products.Count(e => e.Category==category)
                },
                CurrentCategory = category
            };
            //var sql1 = _repository.Products.Count(e => e.Category == category).ToString();
            //var sql2 = _repository.Products.Where(e => e.Category == category).Count().ToString();
            return View(viewModel);
        }

        public FileContentResult GetImage(Guid productGuid)
        {
            Product prod = _repository.Products.FirstOrDefault(p => p.ProductGuid == productGuid);
            if (prod!=null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }

}
