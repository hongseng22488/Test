using System.ComponentModel.DataAnnotations;

namespace ProductInfo.API.Model
{
    public class ProductForCreationDto
    {
        [Required(ErrorMessage = "Name is mandatory")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price is mandatory")]
        public double Price { get; set; }
    }
}
