using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class Cart
    {
        private readonly List<CartLine> _cartLines = new List<CartLine>();

        public void AddItem(Product product, int quantity)
        {
            CartLine cartLine = _cartLines.FirstOrDefault(p => p.Product.ProductGuid == product.ProductGuid);
            if (cartLine == null)
            {
                _cartLines.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                cartLine.Quantity += quantity;
            }
        }

        public void RemovelLine(Product product)
        {
            _cartLines.RemoveAll(p => p.Product.ProductGuid == product.ProductGuid);
        }

        public decimal ComputeTotalValue()
        {
            return _cartLines.Sum(e => e.Product.Price * e.Quantity);
        }

        public void Clear()
        {
            _cartLines.Clear();
        }

        public IEnumerable<CartLine> Lines => _cartLines;

        public class CartLine
        {
            public Product Product { get; set; }
            public int Quantity { get; set; }
        }
    }
}
