using ProductInfo.API.Entities;

namespace ProductInfo.API.Services
{
    public interface IProductInfoRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product?> GetProductAsync(int productId);

        Task AddProductAsync(Product product);

        void DeleteProduct(Product product);
        Task<bool> SaveChangesAsync();
    }
}
