using System.ComponentModel.DataAnnotations;

namespace Asp.net_core.DTO.CarDto
{
    public class PostCarDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name {get; set;}

        [Required(ErrorMessage = "Price is required")]
        public double Price {get; set;}
    }
}