using AutoMapper;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.Entities;
using CareFlow.Core.Interfaces;
using CareFlow.Core.Interfaces.Services;
using CareFlow.Core.Specifications;

namespace CareFlow.Service.Services
{
    public class MedicalHistoryService : IMedicalHistoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MedicalHistoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MedicalHistory> CreateMedicalHistoryAsync(MedicalHistoryToCreateDto dto, Guid doctorId)
        {
            var spec = new MedicalHistorySpecifications(dto.PatientId);
            var existingMedicalHistory = await _unitOfWork.Repository<MedicalHistory>().GetEntityWithAsync(spec);

            if (existingMedicalHistory is not null)
                return existingMedicalHistory;

            var medicalHistory = _mapper.Map<MedicalHistory>(dto);
            medicalHistory.DoctorId = doctorId;
            await _unitOfWork.Repository<MedicalHistory>().AddAsync(medicalHistory);
            var result = await _unitOfWork.Complete();

            if (result > 0)
                return medicalHistory;
            throw new InvalidOperationException("An error occurred while creating medial history entity");

        }
    }
}
