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
        private readonly IInstructionService _instructionService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PrescriptionService(IMedicalHistoryService medicalHistoryService, IUnitOfWork unitOfWork, IMapper mapper, IInstructionService instructionService)
        {
            _medicalHistoryService = medicalHistoryService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _instructionService = instructionService;
        }

        public async Task<PrescriptionToReturnDto> CreatePrescriptionAsync(PrescriptionToCreateDto dto, string userId)
        {
            var doctorSpec = new DoctorSpecifications(userId);
            var doctor = await _unitOfWork.Repository<Doctor>().GetEntityWithAsync(doctorSpec);

            var patient = await _unitOfWork.Repository<Patient>().GetByIdAsync(dto.PatientId);
            if (patient is null)
                throw new ArgumentException("Patient not found, Invalid patient ID.");

            MedicalHistory CreatedMedicalHistory = null;

            if (dto.MedicalHistoryId == Guid.Empty)
            {
                var medicalHistoryDto = _mapper.Map<MedicalHistoryToCreateDto>(dto);
                CreatedMedicalHistory = await _medicalHistoryService.CreateMedicalHistoryAsync(medicalHistoryDto, doctor.Id);
            }

            var prescription = _mapper.Map<Prescription>(dto);
           
            prescription.MedicalHistoryId = CreatedMedicalHistory != null ? CreatedMedicalHistory.Id
                : dto.MedicalHistoryId;
            prescription.DoctorId = doctor.Id;



            var medicinesSpec = new MedicineSpecifications(dto.MedicinesIds);
            var medicines = await _unitOfWork.Repository<Medicine>().GetAllWithSpecAsync(medicinesSpec);
            prescription.Medicines = medicines.ToList();

            var instructions =  _mapper.Map<IReadOnlyList<Instruction>>(dto.Instructions);
            
            foreach(var instruction in instructions)
            {
                instruction.PatientId= prescription.PatientId;
                instruction.DoctorId = doctor.Id;
            }

            prescription.Instructions = instructions.ToList();

            await _unitOfWork.Repository<Prescription>().AddAsync(prescription);
            var result = await _unitOfWork.Complete();

            if (result <= 0)
                throw new InvalidOperationException("An error occurred while creating prescription entity");

           

            var effectiveMedicalHistory = CreatedMedicalHistory is not null ? CreatedMedicalHistory.Id : dto.MedicalHistoryId;
            var spec = new PrescriptionWithPatientAndDoctorSpecifications(prescription.MedicalHistoryId);
            var createdPrescription = await _unitOfWork.Repository<Prescription>().GetEntityWithAsync(spec);

            return _mapper.Map<PrescriptionToReturnDto>(createdPrescription);

        }

        public async Task<IReadOnlyList<PrescriptionToReturnDto>> GetDoctorPrescriptions(string userId)
        {
            var spec = new PrescriptionDoctorSpecifications(userId);
            return await GetPrescriptionsAsync(spec);
        }



        public async Task<IReadOnlyList<PrescriptionToReturnDto>> GetPatientPrescriptions(string userId)
        {
            var spec = new PrescriptionPatientSpecifications(userId);
            return await GetPrescriptionsAsync(spec);

        }



        public async Task<PrescriptionToReturnDto> GetPrescriptionAsync(Guid id,string userId)
        {
            
            var prescription = await _unitOfWork.Repository<Prescription>().GetEntityWithAsync(new PrescriptionSpecifications(id,userId));
            
            if (prescription is null) return null;
            return _mapper.Map<PrescriptionToReturnDto>(prescription);

        }









        private async Task<IReadOnlyList<PrescriptionToReturnDto>> GetPrescriptionsAsync(ISpecification<Prescription> spec)
        {
            var prescriptions =  await _unitOfWork.Repository<Prescription>().GetAllWithSpecAsync(spec);
            
            if (!prescriptions.Any())
                throw new KeyNotFoundException("Prescriptions not found.");

            return _mapper.Map<IReadOnlyList<PrescriptionToReturnDto>>(prescriptions);
        }
    }
}
