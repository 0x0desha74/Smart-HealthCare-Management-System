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
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IMedicalHistoryService _medicalHistoryService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PrescriptionService(IMedicalHistoryService medicalHistoryService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _medicalHistoryService = medicalHistoryService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PrescriptionToReturnDto> CreatePrescriptionAsync(PrescriptionToCreateDto dto, string userId)
        {
            var doctorSpec = new DoctorSpecifications(userId);
            var doctor = await _unitOfWork.Repository<Doctor>().GetEntityWithAsync(doctorSpec);
            MedicalHistory CreatedMedicalHistory = new MedicalHistory();
            if (dto.MedicalHistoryId == Guid.Empty)
            {
                var medicalHistoryDto = _mapper.Map<MedicalHistoryToCreateDto>(dto);
                CreatedMedicalHistory = await _medicalHistoryService.CreateMedicalHistoryAsync(medicalHistoryDto, doctor.Id);
            }

            var prescription = _mapper.Map<Prescription>(dto);
            prescription.MedicalHistoryId = CreatedMedicalHistory.Id;

            var medicinesSpec = new MedicineSpecifications(dto.MedicinesIds);
            var medicines = await _unitOfWork.Repository<Medicine>().GetAllWithSpecAsync(medicinesSpec);

            prescription.Medicines = medicines.ToList();
            prescription.DoctorId = doctor.Id;



            await _unitOfWork.Repository<Prescription>().AddAsync(prescription);
            var result = await _unitOfWork.Complete();
            if (result <= 0)
                throw new InvalidOperationException("An error occurred while creating prescription entity");

            var spec = new PrescriptionWithPatientAndDoctorAndSpecifications(CreatedMedicalHistory.Id);
            var createdPrescription = await _unitOfWork.Repository<Prescription>().GetEntityWithAsync(spec);
            return _mapper.Map<PrescriptionToReturnDto>(createdPrescription);


        }
    }
}
