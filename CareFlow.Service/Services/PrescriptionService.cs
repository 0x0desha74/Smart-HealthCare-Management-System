using AutoMapper;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
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
            //validate doctor
            var doctorSpec = new DoctorSpecifications(userId);
            var doctor = await _unitOfWork.Repository<Doctor>().GetEntityWithAsync(doctorSpec);

            //validate patient
            var patient = await _unitOfWork.Repository<Patient>().GetByIdAsync(dto.PatientId)
                ?? throw new ArgumentException("Patient not found, Invalid patient ID.");

            //validate appointment
            var appointment = await _unitOfWork.Repository<Appointment>().GetEntityWithAsync(new AppointmentSpecifications(dto.AppointmentId, patient.Id, doctor.Id))
                 ?? throw new ArgumentException("Appointment not found, Invalid Appointment ID.");
            if (appointment.Doctor.AppUserId != userId)
                throw new UnauthorizedAccessException("Authorized!, You are not.");

            //create MedicalHistory if needed
            var medicalHistoryId = dto.MedicalHistoryId;
            if (dto.MedicalHistoryId == Guid.Empty)
            {
                var medicalHistoryDto = _mapper.Map<MedicalHistoryToCreateDto>(dto);
                var newMedicalHistory = await _medicalHistoryService.CreateMedicalHistoryAsync(medicalHistoryDto, doctor.Id);
                medicalHistoryId = newMedicalHistory.Id;
            }

            var prescription = _mapper.Map<Prescription>(dto);

            prescription.MedicalHistoryId = medicalHistoryId;
            prescription.DoctorId = doctor.Id;

            //mapping medicines and adding them to the prescription
            var medicines = await _unitOfWork.Repository<Medicine>().GetAllWithSpecAsync(new MedicineSpecifications(dto.MedicinesIds));
            prescription.Medicines = medicines.ToList();

            //creating the instructions and mapping them to the prescription
            var instructions = _mapper.Map<IReadOnlyList<Instruction>>(dto.Instructions);
            foreach (var instruction in instructions)
            {
                instruction.PatientId = prescription.PatientId;
                instruction.DoctorId = doctor.Id;
            }

            prescription.Instructions = instructions.ToList();

            //saving prescription entity
            await _unitOfWork.Repository<Prescription>().AddAsync(prescription);
            var result = await _unitOfWork.Complete();

            if (result <= 0)
                throw new InvalidOperationException("An error occurred while creating prescription entity");

            //mapping created prescription with [instructions,medicines,patient and doctor] loaded
            var spec = new PrescriptionWithPatientAndDoctorSpecifications(prescription.MedicalHistoryId);
            var createdPrescription = await _unitOfWork.Repository<Prescription>().GetEntityWithAsync(spec);

            return _mapper.Map<PrescriptionToReturnDto>(createdPrescription);

        }

        public async Task<IReadOnlyList<PrescriptionToReturnDto>> GetDoctorPrescriptionsAsync(string userId)
        {
            var spec = new PrescriptionDoctorSpecifications(userId);
            return await GetPrescriptionsAsync(spec);
        }



        public async Task<IReadOnlyList<PrescriptionToReturnDto>> GetPatientPrescriptionsAsync(string userId)
        {
            var spec = new PrescriptionPatientSpecifications(userId);
            return await GetPrescriptionsAsync(spec);

        }



        public async Task<PrescriptionToReturnDto> GetPrescriptionByIdAsync(Guid id, string userId)
        {

            var prescription = await _unitOfWork.Repository<Prescription>().GetEntityWithAsync(new PrescriptionSpecifications(id, userId));

            if (prescription is null) return null;
            return _mapper.Map<PrescriptionToReturnDto>(prescription);

        }

        public async Task<PrescriptionToReturnDto> UpdatePrescriptionAsync(Guid id, PrescriptionToUpdateDto dto, string userId)
        {
            if (id != dto.Id)
                throw new ArgumentException("Invalid prescription ID provided.");
            var existingPrescription = await _unitOfWork.Repository<Prescription>().GetEntityWithAsync(new PrescriptionSpecifications(id))
                ?? throw new KeyNotFoundException("Prescription not found.");

            if (existingPrescription.Doctor.AppUserId != userId)
                throw new UnauthorizedAccessException("Authorized!, You are not.");

            var medicines = await _unitOfWork.Repository<Medicine>().GetAllWithSpecAsync(new MedicineSpecifications(dto.MedicinesIds));
            if (!medicines.Any())
                throw new KeyNotFoundException("Some Medicines IDs not found.");

            existingPrescription.Medicines = medicines.ToList();
            _mapper.Map(dto, existingPrescription);

            _unitOfWork.Repository<Prescription>().Update(existingPrescription);
            var result = await _unitOfWork.Complete();

            if (result <= 0)
                throw new InvalidOperationException("Failed to update the prescription entity");
            return _mapper.Map<PrescriptionToReturnDto>(existingPrescription);


        }


        public async Task DeletePrescriptionAsync(Guid id, string userId)
        {
            var prescription = await _unitOfWork.Repository<Prescription>().GetEntityWithAsync(new PrescriptionSpecifications(id, userId))
                ?? throw new KeyNotFoundException("Prescription not found or you are not authorized to delete this prescription.");

            _unitOfWork.Repository<Prescription>().Delete(prescription);
            var result = await _unitOfWork.Complete();

            if (result <= 0)
                throw new InvalidOperationException("Failed to delete the prescription entity");

        }


        public async Task<PrescriptionToReturnDto> UpdatePrescriptionStatusAsync(Guid id, PrescriptionStatusToUpdateDto dto, string userId)
        {
            var prescription = await _unitOfWork.Repository<Prescription>().GetEntityWithAsync(new PrescriptionSpecifications(id))
                ?? throw new KeyNotFoundException("Prescription not found.");

            if (prescription.Doctor.AppUserId != userId)
                throw new UnauthorizedAccessException("Authorized!, You are not.");

            prescription.Status = dto.Status;
            _unitOfWork.Repository<Prescription>().Update(prescription);
            var result = await _unitOfWork.Complete();

            return result > 0 ? _mapper.Map<PrescriptionToReturnDto>(prescription)
                : throw new InvalidOperationException("Failed to update the prescription status");
        }

        private async Task<IReadOnlyList<PrescriptionToReturnDto>> GetPrescriptionsAsync(ISpecification<Prescription> spec)
        {
            var prescriptions = await _unitOfWork.Repository<Prescription>().GetAllWithSpecAsync(spec);

            if (!prescriptions.Any())
                throw new KeyNotFoundException("Prescriptions not found.");

            return _mapper.Map<IReadOnlyList<PrescriptionToReturnDto>>(prescriptions);
        }




    }
}
