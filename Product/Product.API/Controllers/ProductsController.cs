using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.model;
using ProductInfo.API.Model;
using ProductInfo.API.Services;
using System.Collections.Immutable;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace ProductInfo.API.Controllers

{
    [ApiController]
    [Authorize]
    [Route("api/products")]
        public class ProductsController : ControllerBase
    {
        //private readonly ILogger<ProductsController> _logger;
        //private readonly ProductsDataStore _productsDataStore;
        private readonly IProductInfoRepository _productInfoRepository;
        private readonly IMapper _mapper;

        public ProductsController(IProductInfoRepository productInfoRepository, IMapper mapper)
        {
            //_logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _productInfoRepository = productInfoRepository ?? 
                throw new ArgumentNullException(nameof(productInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            try
            {
                var productsEntities = await _productInfoRepository.GetProductsAsync();
              
                return Ok(_mapper.Map<IEnumerable<ProductDto>>(productsEntities));
            
            }
            catch (Exception)
            {
                return StatusCode(500, "A error occur when handling your request, please try again later.");
            }


        }

        [HttpGet("{productid}", Name = "GetProduct")]
        public async Task<IActionResult> GetProduct(int productId)
        {
            try
            {
                var product = await _productInfoRepository.GetProductAsync(productId);
                if (product == null) 
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<ProductDto>(product));
              
            }
            catch (Exception)
            {
                return StatusCode(500, "A error occur when handling your request, please try again later.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct(ProductForCreationDto product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var finalProduct = _mapper.Map<Entities.Product>(product);

                await _productInfoRepository.AddProductAsync(finalProduct);

                await _productInfoRepository.SaveChangesAsync();

                var createdProduct = _mapper.Map<Model.ProductDto>(finalProduct);

                return CreatedAtRoute("GetProduct", 
                    new 
                    { 
                        productId = createdProduct.Id 
                    },
                    createdProduct);
            }
            catch (Exception)
            {
                return StatusCode(500, "A error occur when handling your request, please try again later.");
            }
        }

        [HttpPut("{productId}")]
        public async Task<ActionResult> UpdateProduct(int productId, ProductForUpdateDto product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var productEntity = await _productInfoRepository.GetProductAsync(productId); 
                if (productEntity == null)
                {
                    return NotFound();
                }

                _mapper.Map(product, productEntity);

                await _productInfoRepository.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "A error occur when handling your request, please try again later.");
            }
        }


        [HttpDelete("{productId}")]
        public async Task<ActionResult> DeleteProduct(int productId)
        {
            try
            {
                var productEntity = await _productInfoRepository.GetProductAsync(productId);
                if (productEntity == null)
                {
                    return NotFound();
                }
                _productInfoRepository.DeleteProduct(productEntity);
                await _productInfoRepository.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "A error occur when handling your request, please try again later.");
            }
        }

    }
}
