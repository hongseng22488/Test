using Microsoft.EntityFrameworkCore;
using ProductInfo.API.DbContexts;
using ProductInfo.API.Entities;

namespace ProductInfo.API.Services
{
    public class ProductInfoRepository : IProductInfoRepository
    {
        private readonly ProductsContext _context;

        public ProductInfoRepository(ProductsContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Product>> GetProductsAsync() {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetProductAsync(int productId) {
            return await _context.Products
                .Where(c => c.Id == productId).FirstOrDefaultAsync();
        }

        public async Task AddProductAsync(Product product)
        {
            //var products = await GetProductsAsync();
            _context.Add(product);

        }
        public void DeleteProduct(Product product) 
        { 
            _context.Remove(product);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

    }
}
