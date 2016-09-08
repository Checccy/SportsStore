using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using SportsStore.Domain.Abstruct;
using SportsStore.Domain.Entities;

namespace SportsStore.Web.Areas.ProductArea.Controllers
{
    
    public class AdminController : Controller
    {
        private readonly IProductRepository _productRepository;

        public AdminController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ViewResult Index()
        {
            return View(_productRepository.Products);
        }
        [Authorize]
        public ViewResult Edit(Guid ProductGuid)
        {
            Product product = _productRepository.Products.FirstOrDefault(x => x.ProductGuid == ProductGuid);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product,HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image!=null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData=new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);

                }
                _productRepository.SaveProduct(product);
                TempData["message"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("index");
            }
            else
            {
                return View(product);
            }
        }

        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.SaveProduct(product);
                return RedirectToAction("index");
            }
            else
            {
                return View(product);
            }

        }

        [HttpPost]
        public ActionResult DeleteProduct(Guid productGuid)
        {
            var prod = _productRepository.Products.FirstOrDefault(m => m.ProductGuid == productGuid);
            if (prod!=null)
            {
                _productRepository.DeleteProduct(prod);
                TempData["message"] = string.Format("{0} has been delete", prod.Name);
            }
            return RedirectToAction("index");
        }

       
    }
}
