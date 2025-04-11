using AutoMapper;
using CareFlow.Core.DTOs.In;
using CareFlow.Core.DTOs.Response;
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
    public class PatientService : IPatientService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PatientService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        public async Task<IReadOnlyList<PatientToReturnDto>> GetPatients()
        {
            var spec = new PatientSpecifications();
            var patients = await _unitOfWork.Repository<Patient>().GetAllWithSpecAsync(spec);
            if (patients is null) return null;
            return _mapper.Map<IReadOnlyList<Patient>, IReadOnlyList<PatientToReturnDto>>(patients);
        }


        public async Task<PatientToReturnDto> GetPatient(Guid id)
        {
            var spec = new PatientSpecifications(id);
            var patient = await _unitOfWork.Repository<Patient>().GetEntityWithAsync(spec);
            if (patient is null) return null;
           return _mapper.Map<Patient, PatientToReturnDto>(patient);

        }


        public async Task<PatientDto> CreatePatient(PatientDto patientDto)
        {
            var patient = _mapper.Map<PatientDto, Patient>(patientDto);

            await _unitOfWork.Repository<Patient>().AddAsync(patient);
            var result = await _unitOfWork.Complete();
            if (result > 0) return _mapper.Map<Patient, PatientDto>(patient);
            return null;
        }

        public async Task<bool> DeletePatient(Guid id)
        {
            var patient = await _unitOfWork.Repository<Patient>().GetByIdAsync(id);
            if (patient is null) return false;
            _unitOfWork.Repository<Patient>().Delete(patient);
            var result = await _unitOfWork.Complete();
            return result > 0;
        }

       
        public async Task<PatientToReturnDto> UpdatePatient(PatientDto patientDto)
        {
            if (patientDto is null || patientDto.id == Guid.Empty)
                throw new KeyNotFoundException("Invalid patient data");

            var existingPatient = await _unitOfWork.Repository<Patient>().GetByIdAsync(patientDto.id);
            if(existingPatient is null) throw new KeyNotFoundException("Patient not found");

            _mapper.Map(patientDto, existingPatient);

            _unitOfWork.Repository<Patient>().Update(existingPatient);

            var result = await _unitOfWork.Complete();

            if (result > 0) 
            return _mapper.Map<Patient, PatientToReturnDto>(existingPatient);
            else
                throw new InvalidOperationException("An error occurred while update");

        }
    }
}
