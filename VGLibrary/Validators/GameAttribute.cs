using VGLibrary.Models;
using System.ComponentModel.DataAnnotations;

namespace VGLibrary.Validators
{
    public class GameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {            
            Game g = (Game)validationContext.ObjectInstance;

            if (g.Image == null ) 
            {
                return new ValidationResult("Image field cannot be left empty");
            }

            if (g.Title == null ) 
            {
                return new ValidationResult("Title field cannot be left empty");
            }            

            if (g.Genre == null ) 
            {
                return new ValidationResult("Genre field cannot be left empty");
            }            

            if (g.Year < 1958 ) 
            {
                return new ValidationResult("Not a valid year!");
            }

            if (g.Platform == null) 
            {
                return new ValidationResult("Platform field cannot be left empty");
            }

            if (g.Rating == null) 
            {
                return new ValidationResult("Not a valid rating ");
            }

            return ValidationResult.Success;

        }
    }
}
