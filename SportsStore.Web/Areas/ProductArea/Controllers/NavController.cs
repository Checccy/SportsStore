using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SportsStore.Domain.Abstruct;

namespace SportsStore.Web.Areas.ProductArea.Controllers
{
    public class NavController : Controller
    {
        private readonly IProductRepository _productRepository;

        public NavController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public PartialViewResult Menu()
        {
            IEnumerable<string> catecorys = _productRepository.Products
                .Select(p => p.Category)
                .Distinct()
                .OrderBy(p => p);
            return PartialView(catecorys);
        }
    }
}