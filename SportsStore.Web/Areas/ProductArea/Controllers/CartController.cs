using System;
using System.Linq;
using System.Web.Mvc;
using SportsStore.Domain.Abstruct;
using SportsStore.Domain.Entities;
using SportsStore.Web.Areas.ProductArea.Models;

namespace SportsStore.Web.Areas.ProductArea.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductRepository _productRepository;

        public CartController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public RedirectToRouteResult AddToCart(Cart cart,Guid productGuid,string returnUrl)
        {
            Product product = _productRepository.Products.FirstOrDefault(p => p.ProductGuid == productGuid);
            if (product!=null)
            {
                cart.AddItem(product,1);
            }
            return RedirectToAction("index", new {returnUrl});
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart,Guid productGuid, string returnUrl)
        {
            Product product = _productRepository.Products.FirstOrDefault(p => p.ProductGuid == productGuid);
            if (product!=null)
            {
                cart.RemovelLine(product);
            }
            return RedirectToAction("index",new {returnUrl});
        }

        // GET: ProductArea/Cart
        public ActionResult Index(Cart cart,string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart= cart,
                ReturnUrl = returnUrl
            });
        }
    }
}