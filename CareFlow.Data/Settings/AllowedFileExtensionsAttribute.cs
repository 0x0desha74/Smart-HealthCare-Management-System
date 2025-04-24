using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CareFlow.Core.Settings
{

    public class AllowedFileExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;



        public AllowedFileExtensionsAttribute(string[] extensions)
        {
            _extensions = extensions;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file is not null)
            {
                var extension = Path.GetExtension(file.FileName);
                if (!_extensions.Contains(extension.ToLower()))
                    return new ValidationResult("Invalid file extension");

            }
            return ValidationResult.Success;
        }

    }
}
