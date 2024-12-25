using System.ComponentModel.DataAnnotations;
using UdemyAssignment.Validator;
namespace UdemyAssignment.Models
{
    public class Order : IValidatableObject
    {
        public int? OrderNo  { get; set; }

        [Required(ErrorMessage = "OrderDate can't be blank")]
        
        [DateValidator(ErrorMessage = "Invalid DateTime")] //custom validator
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "InvoicePrice can't be blank")]
        [Range(0.01,double.MaxValue,ErrorMessage = "InvoicePrice must be valid")]
        public double? InvoicePrice { get; set; }

        [Required(ErrorMessage = "At least one Product is required")]
        [MinLength(1,ErrorMessage ="Minimum number of product is one")]
        public List<Product> Products { get; set; }



        //When all the validations are checked then it execute this method.
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            double cost = 0.0;
            foreach (var item in Products)
            {
                cost += (item.Price * item.Quantity);
            }
            if (cost != InvoicePrice)
            {
               yield return new ValidationResult("InvoicePrice doesn't match with the total cost of the specified products in the order.");
            }

        }
    }
}
