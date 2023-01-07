using System.ComponentModel.DataAnnotations;

namespace ProductInfo.API.Model
{
    public class ProductForUpdateDto
    {
        [Required(ErrorMessage = "Name field is mandatory")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public double Price { get; set; }
    }
}
