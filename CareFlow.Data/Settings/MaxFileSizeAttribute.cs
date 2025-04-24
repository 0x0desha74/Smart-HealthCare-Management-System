using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CareFlow.Core.Settings
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSizeInBytes;
        private readonly string[] _extensions;

        public MaxFileSizeAttribute(int maxFileSizeInBytes)
        {
            _maxFileSizeInBytes = maxFileSizeInBytes;
        }


        public MaxFileSizeAttribute(string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext context)
        {
            var file = value as IFormFile;
            if (file is not null && file.Length > _maxFileSizeInBytes)
                return new ValidationResult($"Max file size is {_maxFileSizeInBytes / (1024 * 1024)} MB");

            return ValidationResult.Success;

        }




    }
}
