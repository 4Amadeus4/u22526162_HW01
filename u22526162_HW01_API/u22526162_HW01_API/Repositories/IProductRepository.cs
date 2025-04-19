using u22526162_HW01_API.Models;

namespace u22526162_HW01_API.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductList();
        Task<Product?> GetProductById(int _id);
        Task<Product> AddProduct(Product _product);
        Task<Product> UpdateProduct(Product _product);

        Task<bool> DeleteProduct(int _id);
    }
}