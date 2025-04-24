using AutoMapper;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.Entities;
using CareFlow.Core.Interfaces;
using CareFlow.Core.Interfaces.Services;
using CareFlow.Core.Specifications;
using CareFlow.Data.Entities;
using Microsoft.AspNetCore.Hosting;

namespace CareFlow.Service.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;
        public DocumentService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _env = env;
        }

        public async Task UploadDocumentAsync(DocumentToUploadDto dto, string userId)
        {
            if (dto.File is null || dto.File.Length == 0)
                throw new ArgumentException("Invalid File, File Is Required");
            var medicalHistory = await _unitOfWork.Repository<MedicalHistory>().GetEntityWithAsync(new MedicalHistorySpecifications(dto.MedicalHistoryId, dto.PatientId))
                ?? throw new KeyNotFoundException("Patient OR MedicalHistory not found.");

            //1.Get located file path

            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), _env.WebRootPath, "documents");


            //2.Get file name to make it unique
            string fileName = $"{Guid.NewGuid()}{dto.File.FileName}";

            //3. Get file path = folderPath + fileName
            string filePath = Path.Combine(folderPath, fileName);

            //4. Save file as stream [Data Per Time]
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await dto.File.CopyToAsync(fileStream);
            }

            var document = new Document()
            {
                FileName = fileName,
                FilePath = filePath,
                FileType = dto.File.FileName,
                FileSize = dto.File.Length,
                MedicalHistoryId = dto.MedicalHistoryId,
                PatientId = dto.PatientId,
                IsActive = true,
                UploadedAt = DateTime.UtcNow,
                DeletedAt = null,
                UploadedByUserId = userId,
                Version = "1.0"
            };
            await _unitOfWork.Repository<Document>().AddAsync(document);
            var result = await _unitOfWork.Complete();

            if (result <= 0)
                throw new InvalidOperationException("Failed create document entity");

        }



    }
}
