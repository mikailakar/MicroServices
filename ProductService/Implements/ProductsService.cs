using Microsoft.EntityFrameworkCore;
using ProductService.Models;
using ProductService.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductService.Implements
{
    public class ProductsService : IProductsService
    {
        private readonly ProductContext _context;
        public ProductsService(ProductContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }
        public async Task<Product> AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
