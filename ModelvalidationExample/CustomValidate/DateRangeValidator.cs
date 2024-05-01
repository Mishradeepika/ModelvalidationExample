using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ModelvalidationExample.CustomValidate
{
    public class DateRangeValidatorAttribute : ValidationAttribute
    {
        public string Propertyname {  get; set; }
        public DateRangeValidatorAttribute(string propertyName) 
        {
            Propertyname=propertyName;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value == null) 
            {
                DateTime to_date = Convert.ToDateTime(value);
                PropertyInfo? propertyinfo = validationContext.ObjectType.GetProperty(Propertyname);

              DateTime from_date= Convert.ToDateTime( propertyinfo.GetValue(validationContext.ObjectInstance));

                if(from_date >to_date)
                {
                    return new ValidationResult(ErrorMessage, new string[] { Propertyname, validationContext.MemberName });
                }
                else
                {
                    return ValidationResult.Success;
                }


            }
            return null;
        }
    }
}
