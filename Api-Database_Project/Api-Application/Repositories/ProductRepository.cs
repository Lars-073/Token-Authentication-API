using Api_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_Application.Repositories
{
    public class ProductRepository : IDisposable
    {
        private API_Entities _context = new API_Entities();

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetMostExpensiveProduct()
        {
            return _context.Products.OrderByDescending(i => i.Price).Take(1).First();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}