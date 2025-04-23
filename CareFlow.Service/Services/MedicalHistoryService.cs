using AutoMapper;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
using CareFlow.Core.Entities;
using CareFlow.Core.Interfaces;
using CareFlow.Core.Interfaces.Services;
using CareFlow.Core.Specifications;
using CareFlow.Data.Entities;

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

        public async Task<MedicalHistoryToReturnDto> CreateMedicalHistoryAsync(MedicalHistoryToCreateDto dto, string doctorUserId)
        {
            var spec = new MedicalHistoryWithPatientIdSpecifications(dto.PatientId);
            var existingMedicalHistory = await _unitOfWork.Repository<MedicalHistory>().GetEntityWithAsync(spec);

            if (existingMedicalHistory is not null)
                return _mapper.Map<MedicalHistoryToReturnDto>(existingMedicalHistory);

            var doctor = await _unitOfWork.Repository<Doctor>().GetEntityWithAsync(new DoctorSpecifications(doctorUserId));
            
            var medicalHistory = _mapper.Map<MedicalHistory>(dto);

            medicalHistory.DoctorId = doctor.Id;
            await _unitOfWork.Repository<MedicalHistory>().AddAsync(medicalHistory);
            var result = await _unitOfWork.Complete();

            if (result <= 0) 
            throw new InvalidOperationException("An error occurred while creating medial history entity");
            var createdMedicalHistory = await _unitOfWork.Repository<MedicalHistory>().GetEntityWithAsync(new MedicalHistoryWithPatientIdSpecifications(medicalHistory.PatientId));
                return _mapper.Map<MedicalHistoryToReturnDto>(createdMedicalHistory); 

        }

        public async Task<IReadOnlyList<MedicalHistoryToReturnDto>> GetMedicalHistoriesAsync(string doctorUserId)
        {
            var medicalHistories = await _unitOfWork.Repository<MedicalHistory>().GetAllWithSpecAsync(new MedicalHistorySpecifications(doctorUserId));
            if (!medicalHistories.Any())
                throw new KeyNotFoundException("Medical histories not found Or you are not authorized to view these histories");
            return _mapper.Map<IReadOnlyList<MedicalHistoryToReturnDto>>(medicalHistories);
        }

        public async Task<MedicalHistoryToReturnDto> GetMedicalHistoryAsync(Guid id, string userId)
        {
            var medicalHistory = await _unitOfWork.Repository<MedicalHistory>().GetEntityWithAsync(new MedicalHistorySpecifications(id))
                ?? throw new KeyNotFoundException("Medical History not found.");

            if (medicalHistory.Doctor?.AppUserId != userId && medicalHistory.Patient?.AppUserId != userId)
                throw new UnauthorizedAccessException("Authorized!, You are not.");

            return _mapper.Map<MedicalHistoryToReturnDto>(medicalHistory);

        }
    }
}
