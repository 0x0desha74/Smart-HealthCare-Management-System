using AutoMapper;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
using CareFlow.Core.Entities;
using CareFlow.Core.Interfaces;
using CareFlow.Core.Interfaces.Services;
using CareFlow.Core.Specifications;
using CareFlow.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<InstructionToReturnDto> CreateInstructionAsync(InstructionToCreateDto dto,Guid prescriptionId,string userId)
        {
           
            var prescription = await _unitOfWork.Repository<Prescription>().GetByIdAsync(prescriptionId);

            if (prescription is null)
                throw new KeyNotFoundException("Prescription not found, Invalid prescription ID provided");
            var doctor = await _unitOfWork.Repository<Doctor>().GetEntityWithAsync(new DoctorSpecifications(userId));

            if (prescription.DoctorId != doctor.Id)
                throw new UnauthorizedAccessException("You are not authorized to modify this prescription.");
            var instruction = _mapper.Map<Instruction>(dto);
            instruction.PatientId = prescription.PatientId;
            instruction.PrescriptionId = prescriptionId;
            instruction.DoctorId = doctor.Id;

            await _unitOfWork.Repository<Instruction>().AddAsync(instruction);
            var result = await _unitOfWork.Complete();

            if (result > 0)
                return _mapper.Map<InstructionToReturnDto>(instruction);
            throw new InvalidOperationException("An error occurred while creating instruction entity");
        }
    }
}
