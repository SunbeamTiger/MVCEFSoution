using DBProject.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Models
{
    public class ProductRepository : IProductRepository
    {
        private GSContext _context;
        public ProductRepository(GSContext GSCon) 
        {
            _context = GSCon;
        }  
        public IEnumerable<Product> GetAllProductsandPrices()
        {
            var myProducts = _context.Products.Select(p => new Product
            {
                ProductName = p.ProductName,
                UnitPrice = p.UnitPrice
            }).ToList();
            return myProducts;  
        }

        public Supplier GetProductById(int ProductID)
        {
            throw new NotImplementedException();
        }

        //public Supplier GetProductById(int ProductID)
        //{

        //}
    }
}
