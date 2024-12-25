using System.ComponentModel.DataAnnotations;

namespace UdemyAssignment.Models
{
    public class Product
    {
        [Required(ErrorMessage = "ProductCode can't be blank")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "ProductCode must be valid")]
        public int ProductCode { get; set; }

        [Required(ErrorMessage = "Price can't be blank")]
        [Range(0.01,double.MaxValue,ErrorMessage = "Price must be valid positive number")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Quantity can't be blank")]
        [Range(1,int.MaxValue,ErrorMessage ="Quantity must be valid")]
        public int Quantity {  get; set; }
    }
}
