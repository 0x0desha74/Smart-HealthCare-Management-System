using AutoMapper;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
using CareFlow.Core.Interfaces;
using CareFlow.Core.Interfaces.Services;
using CareFlow.Core.Specifications;
using CareFlow.Data.Entities;

namespace CareFlow.Service.Services
{
    public class InstructionService : IInstructionService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public InstructionService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<InstructionToReturnDto> CreateInstructionAsync(InstructionToCreateDto dto, Guid prescriptionId, string userId)
        {

            var prescription = await _unitOfWork.Repository<Prescription>().GetEntityWithAsync(new PrescriptionSpecifications(prescriptionId));

            if (prescription is null)
                throw new KeyNotFoundException("Prescription not found, Invalid prescription ID provided");
            var doctor = await _unitOfWork.Repository<Doctor>().GetEntityWithAsync(new DoctorSpecifications(userId));

            if (prescription.DoctorId != doctor.Id)
                throw new UnauthorizedAccessException("You are not authorized to modify this prescription.");

            var patient = await _unitOfWork.Repository<Patient>().GetByIdAsync(prescription.Patient.Id);
            if (patient is null)
                throw new KeyNotFoundException("Patient not found");

            var instruction = _mapper.Map<Instruction>(dto);

            instruction.PatientId = patient.Id;
            instruction.PrescriptionId = prescriptionId;
            instruction.DoctorId = doctor.Id;

            await _unitOfWork.Repository<Instruction>().AddAsync(instruction);
            var result = await _unitOfWork.Complete();

            if (result > 0)
                return _mapper.Map<InstructionToReturnDto>(instruction);
            throw new InvalidOperationException("An error occurred while creating instruction entity");
        }

        public async Task<InstructionToReturnDto> GetInstructionForPrescription(Guid prescriptionId, Guid instructionId, string userId)
        {
            var prescription = await _unitOfWork.Repository<Prescription>().GetEntityWithAsync(new PrescriptionSpecifications(prescriptionId));

            if (prescription is null)
                throw new KeyNotFoundException("Prescription not found.");

            if (prescription.Doctor.AppUserId != userId && prescription.Patient.AppUserId != userId)
                throw new UnauthorizedAccessException("You are not authorized to view this instruction");

            var instruction = await _unitOfWork.Repository<Instruction>().GetEntityWithAsync(new InstructionSpecifications(prescriptionId, instructionId));

            if (instruction is null)
                throw new KeyNotFoundException("Instruction not found");

            return _mapper.Map<InstructionToReturnDto>(instruction);
        }

        public async Task<IReadOnlyList<InstructionToReturnDto>> GetInstructionsForPrescription(Guid prescriptionId, string userId)
        {
            var prescription = await _unitOfWork.Repository<Prescription>().GetEntityWithAsync(new PrescriptionSpecifications(prescriptionId));
            if (prescription is null)
                throw new KeyNotFoundException("Prescription not found");
            if (prescription.Doctor.AppUserId != userId && prescription.Patient.AppUserId != userId)
                throw new UnauthorizedAccessException("You are not authorized to view instructions");

            var instructions = await _unitOfWork.Repository<Instruction>().GetAllWithSpecAsync(new InstructionSpecifications(prescriptionId));

            if (!instructions.Any())
                throw new KeyNotFoundException("Instructions not found.");
            return _mapper.Map<IReadOnlyList<InstructionToReturnDto>>(instructions);
        }










    }
}
