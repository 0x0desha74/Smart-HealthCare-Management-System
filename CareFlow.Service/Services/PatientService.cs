using AutoMapper;
using CareFlow.Core.DTOs.In;
using CareFlow.Core.Interfaces;
using CareFlow.Core.Interfaces.Services;
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

        public async Task<PatientDto> CreatePatient(PatientDto patientDto)
        {
            var patient = _mapper.Map<PatientDto, Patient>(patientDto);

            await _unitOfWork.Repository<Patient>().AddAsync(patient);
            var result = await _unitOfWork.Complete();
            if (result > 0) return _mapper.Map<Patient, PatientDto>(patient);
            return null;
        }

        public Task DeletePatient(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PatientDto> GetPatient(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<PatientDto>> GetPatients()
        {
            throw new NotImplementedException();
        }

        public Task<PatientDto> UpdatePatient(PatientDto patientDto)
        {
            throw new NotImplementedException();
        }
    }
}
