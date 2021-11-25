using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_login.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_login.Data
{
    public class ProductRepo : IProductRepo
    {
        private readonly UserContext _context;
        public ProductRepo(UserContext context)
        {
            _context = context;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
              .FirstOrDefaultAsync(p => p.Id == id);
        }

        public Product Create(Product product)
        {
            _context.Products.Add(product);
            product.Id = _context.SaveChanges();
            return product;

            // return await _context.Products.Add(product);
            // product.Id = _context.SaveChanges();
        }



        public async Task<IReadOnlyList<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }





    }
}