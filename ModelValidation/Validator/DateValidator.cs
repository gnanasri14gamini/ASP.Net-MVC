using System.ComponentModel.DataAnnotations;

namespace UdemyAssignment.Validator
{
    public class DateValidator : ValidationAttribute // should inherit this class for custom validator
    {
        public override bool IsValid(object? value)
        {
            if(value == null) return false;
            else
            {
                DateTime date = (DateTime)value;
                if(date.Year < 2020)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

    }
}
