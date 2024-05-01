using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ModelvalidationExample.CustomValidate;

namespace ModelvalidationExample.Models
{
    public class Person
    {
        [Required(ErrorMessage = "{0} is not empty")]
        [Display(Name="Person Name")]
        [StringLength(40,MinimumLength =4,ErrorMessage ="{0} must be minimun length is 4 chachter")]
        [RegularExpression("^[A-Za-z .]$",ErrorMessage ="{0} must be alphabet only")]
        public string ? name {  get; set; }
        [EmailAddress(ErrorMessage ="{0} should be proper email address")]
        public string? Email { get; set; }

        [Phone(ErrorMessage ="{0} should contains 10 digits")]
       // [ValidateNever]
        public string? Phone { get; set; }
        [Required (ErrorMessage ="Password can not empty")]
        public string? Passward { get; set; }
        [Required(ErrorMessage = "Confirmed Password can not empty")]
        [Compare ("Passward",ErrorMessage ="{0} and {1} is not match")]
        public string? ConfirmPassward { get; set; }
        [Range(0,999.99,ErrorMessage ="{0} is bwteen {1} and {2}")]
        public Double? Price { get; set; }
        [miniumyearValidator]
        public DateTime? dateofbirth { get; set; }

        public DateTime? Fromdate { get; set; }
        [DateRangeValidatorAttribute("Fromdate", ErrorMessage="FromDate is old and equal to Todate")]
        public DateTime? ToDate { get; set; }
        public override string ToString()
        {
            return $" Person name is {name} Email  is :{Email} Phone is :{Phone} passward is :{Passward} ComfirmPassward is :{ConfirmPassward} Prize is : {Price}";
        }
    }
}
