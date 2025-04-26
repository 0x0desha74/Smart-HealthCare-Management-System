using AutoMapper;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
using CareFlow.Core.Entities;
using CareFlow.Core.Interfaces;
using CareFlow.Core.Interfaces.Services;
using CareFlow.Core.Settings;
using CareFlow.Core.Specifications;
using CareFlow.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace CareFlow.Service.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public DocumentService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _env = env;
            _config = config;
        }

        public async Task<(byte[] fileDate, string contentType, string fileName)> DownloadDocumentAsync(Guid id, string userId)
        {
            var document = await GetDocumentAsync(id, userId);

            var filePath = Path.Combine(_env.WebRootPath, "documents", document.FileName);

            if (!File.Exists(filePath))
                throw new FileNotFoundException("file not exist on the disk.");

            var fileData = File.ReadAllBytes(filePath);

            var contentType = GetFileContextType(document.FileName);

            return (fileData, contentType, document.FileName);
        }

        public async Task<DocumentToReturnDto> GetDocumentAsync(Guid id, string userId)
        {
            var document = await _unitOfWork.Repository<Document>().GetEntityWithAsync(new DocumentSpecifications(id))
                ?? throw new KeyNotFoundException("Document not found.");
            

            if (document.Patient.AppUserId != userId && document.MedicalHistory.Doctor.AppUserId != userId)
                throw new UnauthorizedAccessException("Authorize!, You are not.");

            return  _mapper.Map<DocumentToReturnDto>(document);
        }

        public async Task UploadDocumentAsync(DocumentToUploadDto dto, string userId)
        {
            if (dto.File is null || dto.File.Length == 0)
                throw new ArgumentException("Invalid File, File Is Required");
            var medicalHistory = await _unitOfWork.Repository<MedicalHistory>().GetEntityWithAsync(new MedicalHistorySpecifications(dto.MedicalHistoryId, dto.PatientId))
                ?? throw new KeyNotFoundException("Patient Or MedicalHistory not found.");

            if (medicalHistory.Doctor.AppUserId != userId && medicalHistory.Patient.AppUserId != userId)
                throw new UnauthorizedAccessException("Authorized!, You are not");


                string folderPath = Path.Combine( _env.WebRootPath, "documents"); // folderPath =>/wwwroot/documents/

            string fileExtension = Path.GetExtension(dto.File.FileName);
           string fileName = $"{Guid.NewGuid()}{fileExtension}";

           
            //filePath => /wwwroot/documents/{fileName}
            string filePath = Path.Combine(folderPath, fileName);

           
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await dto.File.CopyToAsync(fileStream);
            }

            var document = new Document()
            {
                FileName = fileName,
                FileUrl = $"/documents/{fileName}",
                FileType = dto.File.ContentType,
                FileSize = dto.File.Length,
                MedicalHistoryId = dto.MedicalHistoryId,
                PatientId = dto.PatientId,
                IsActive = true,
                UploadedAt = DateTime.UtcNow,
                DeletedAt = null,
                UploadedByUserId = userId
            };
            await _unitOfWork.Repository<Document>().AddAsync(document);
            var result = await _unitOfWork.Complete();

            if (result <= 0)
                throw new InvalidOperationException("Failed create document entity");

        }


        private string GetFileContextType(string fileName)
        {
            var extension = Path.GetExtension(fileName);
            return extension switch
            {
                ".jpg" or ".jpeg"=> "image/jpeg",
                "png" => "image/png",
                "pdf" => "application/pdf",
                _ => "application/octet-stream"
            };
        }
        

    }
}
