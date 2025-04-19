using Microsoft.EntityFrameworkCore;
using u22526162_HW01_API.Data;
using u22526162_HW01_API.Models;

namespace u22526162_HW01_API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductList()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetProductById(int _id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.ProductId == _id);
        }

        public async Task<Product> AddProduct(Product _product)
        {
            _context.Products.Add(_product);
            await _context.SaveChangesAsync();
            return _product;
        }

        public async Task<Product> UpdateProduct(Product _product)
        {
            var existingProduct = await _context.Products.FindAsync(_product.ProductId);
            if (existingProduct == null) return null;

            existingProduct.ProductName = _product.ProductName;
            existingProduct.ProductPrice = _product.ProductPrice;
            existingProduct.ProductDescription = _product.ProductDescription;

            await _context.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<bool> DeleteProduct(int _id)
        {
            var product = await _context.Products.FindAsync(_id);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}