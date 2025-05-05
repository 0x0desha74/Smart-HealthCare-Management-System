using AutoMapper;
using CareFlow.Core.DTOs.Response;
using CareFlow.Data.Entities;
using Microsoft.Extensions.Configuration;

namespace CareFlow.Core.Settings
{
    public class DocumentUrlResolver : IValueResolver<Document, DocumentToReturnDto, string>
    {
        private readonly IConfiguration _config;

        public DocumentUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Document source, DocumentToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.FileUrl))
            {
                return $"{_config["ApiBaseUrl"]}{source.FileUrl}";
            }
            return string.Empty;
        }
    }
}
