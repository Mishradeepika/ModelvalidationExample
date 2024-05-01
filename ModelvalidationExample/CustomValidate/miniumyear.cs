using System.ComponentModel.DataAnnotations;

namespace ModelvalidationExample.CustomValidate
{
    public class miniumyearValidator:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            if(value != null)
            {
                DateTime date = (DateTime)value;
                if(date.Year >=2000)
                {
                    return new ValidationResult("minimum result allowed 2000");
                }
                else
                {
                    return ValidationResult .Success;
                }

            }
            return null;
        }
    }
}
