using ProductInfo.API.Model;

namespace ProductInfo.API
{
    public class ProductsDataStore
    {
        public List<ProductDto> Products { get; set; }
        public static ProductsDataStore Current { get; } = new ProductsDataStore();
        public ProductsDataStore()
        {
            Products = new List<ProductDto>()
            {
                new ProductDto()
                {
                    Id = 1,
                    Name = "yoyo",
                    Price = 1.99
                },
                new ProductDto()
                {
                    Id = 2,
                    Name = "yoyo 2",
                    Price = 2.99
                }
            };

        }
    }
}
