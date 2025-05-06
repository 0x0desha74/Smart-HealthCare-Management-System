using AutoMapper;
using CareFlow.Core.DTOs.Response;
using CareFlow.Data.Entities;
using Microsoft.Extensions.Configuration;

namespace CareFlow.Core.Settings
{
    public class DocumentDownloadUrlResolver : IValueResolver<Document, DocumentToReturnDto, string>
    {
        private IConfiguration _config;

        public DocumentDownloadUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Document source, DocumentToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.FileUrl))
            {
                return $"{_config["ApiBaseUrl"]}/api/documents/download/{source.Id}";
            }
            return string.Empty;
        }
    }
}
