using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_login.Models;

namespace dotnet_login.Data
{
    public interface IProductRepo
    {
        Task<Product> GetProductByIdAsync(int id);

        Product Create(Product product);

        
        Task<IReadOnlyList<Product>> GetAllProductsAsync();


    }
}