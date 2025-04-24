using AutoMapper;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
using CareFlow.Core.Interfaces;
using CareFlow.Core.Interfaces.Services;
using CareFlow.Core.Specifications;
using CareFlow.Data.Entities;

namespace CareFlow.Service.Services
{
    public class AllergyService : IAllergyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AllergyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AllergyDto> AddAllergyToPatient(Guid patientId, AllergyDto allergyDto)
        {
            if (allergyDto.Id != Guid.Empty)
                throw new ArgumentException("Allergy Id must be null");

            var patient = await _unitOfWork.Repository<Patient>().GetByIdAsync(patientId);
            if (patient is null)
                throw new KeyNotFoundException("Attempting to add allergy to not existed patient");

            var allergy = _mapper.Map<Allergy>(allergyDto);

            allergy.PatientId = patientId;
            await _unitOfWork.Repository<Allergy>().AddAsync(allergy);
            var result = await _unitOfWork.Complete();

            if (result > 0) return _mapper.Map<AllergyDto>(allergy);
            throw new InvalidOperationException("An error occurred while add allergy to patient");

        }

        public async Task<bool> DeleteAllergyFromPatient(Guid patientId, Guid allergyId)
        {
            var spec = new AllergySpecifications(patientId, allergyId);
            var allergy = await _unitOfWork.Repository<Allergy>().GetEntityWithAsync(spec);
            if (allergy is null) throw new KeyNotFoundException("Invalid allergy Id provided");
            _unitOfWork.Repository<Allergy>().Delete(allergy);
            var result = await _unitOfWork.Complete();
            return result > 0;
        }

        public async Task<IReadOnlyList<AllergyToReturnDto>> GetAllergiesForPatient(Guid patientId)
        {
            var patient = await _unitOfWork.Repository<Patient>().GetByIdAsync(patientId);
            if (patient is null) throw new KeyNotFoundException("Invalid patient id provided");
            var spec = new AllergySpecifications(patientId);
            var allergies = await _unitOfWork.Repository<Allergy>().GetAllWithSpecAsync(spec);
            if (allergies is null) return null;
            return _mapper.Map<IReadOnlyList<AllergyToReturnDto>>(allergies);
        }




    }
}
