using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Abstruct;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private readonly ProductsDBContext _context=new ProductsDBContext();

        public IQueryable<Product> Products => _context.Products;

        public void SaveProduct(Product product)
        {
           
            if (product.ProductGuid==Guid.Empty)
            {
                product.ProductGuid=Guid.NewGuid();
                _context.Products.Add(product);
            }
            else
            {
                _context.Entry(product).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
