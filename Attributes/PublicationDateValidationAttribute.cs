using System.ComponentModel.DataAnnotations;
using task1.Model;

namespace task1.Attributes
{
    public class PublicationDateValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            News news = validationContext.ObjectInstance as News;
            if ((DateTime) value > DateTime.Now.AddDays(7))
            {
                return new ValidationResult("Publication date must be within 7 days of creation date."); 
            } 
            return ValidationResult.Success;
        }
    }
}
