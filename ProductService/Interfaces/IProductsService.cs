using ProductService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductService.Interfaces
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> AddProductAsync(Product product);
    }
}