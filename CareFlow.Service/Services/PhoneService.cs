using AutoMapper;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
using CareFlow.Core.Interfaces;
using CareFlow.Core.Interfaces.Services;
using CareFlow.Core.Specifications;
using CareFlow.Data.Entities;

namespace CareFlow.Service.Services
{
    public class PhoneService : IPhoneService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PhoneService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<IReadOnlyList<PhoneToReturnDto>> GetPhonesOfPatient(Guid patientId)
        {
            var spec = new PhoneSpecifications(patientId);

            var phones = await _unitOfWork.Repository<Phone>().GetAllWithSpecAsync(spec);
            if (phones is null) return null;
            return _mapper.Map<IReadOnlyList<PhoneToReturnDto>>(phones);
        }


        public async Task<PhoneToReturnDto> GetPhoneOfPatient(Guid patientId, Guid id)
        {
            var spec = new PhoneSpecifications(patientId, id);
            var phone = await _unitOfWork.Repository<Phone>().GetEntityWithAsync(spec);
            if (phone is null) return null;
            return _mapper.Map<PhoneToReturnDto>(phone);
        }



        public async Task<PhoneDto> CreatePhone(PhoneDto phoneDto, Guid patientId)
        {
            if (phoneDto.Id != Guid.Empty)
                throw new ArgumentException("Id must be null");
            var patient = await _unitOfWork.Repository<Patient>().GetByIdAsync(patientId);
            if (patient is null)
                throw new KeyNotFoundException("Invalid Patient Id Provided");

            var updatedPhone = _mapper.Map<PhoneDto, Phone>(phoneDto);
            updatedPhone.PatientId = patientId;

            await _unitOfWork.Repository<Phone>().AddAsync(updatedPhone);
            var result = await _unitOfWork.Complete();
            if (result > 0) return _mapper.Map<PhoneDto>(updatedPhone);
            throw new InvalidOperationException("An error occurred while creating the phone");

        }



        public async Task<bool> DeletePhone(Guid patientId, Guid id)
        {
            var spec = new PhoneSpecifications(patientId, id);
            var phone = await _unitOfWork.Repository<Phone>().GetEntityWithAsync(spec);
            if (phone is null) throw new KeyNotFoundException("Invalid phone Id provided");
            _unitOfWork.Repository<Phone>().Delete(phone);
            var result = await _unitOfWork.Complete();
            return result > 0;
        }



        public async Task<PhoneToReturnDto> UpdatePhone(Guid patientId, PhoneDto phoneDto)
        {
            if (phoneDto is null || phoneDto.Id == Guid.Empty)
                throw new KeyNotFoundException("Invalid phone data");
            var spec = new PhoneSpecifications(patientId, phoneDto.Id);
            var existingPhone = await _unitOfWork.Repository<Phone>().GetEntityWithAsync(spec);
            if (existingPhone is null) throw new KeyNotFoundException("phone not found");
            _mapper.Map(phoneDto, existingPhone);

            _unitOfWork.Repository<Phone>().Update(existingPhone);
            var result = await _unitOfWork.Complete();
            if (result > 0) return _mapper.Map<PhoneToReturnDto>(existingPhone);
            throw new InvalidOperationException("An error happed occurred while updating the phone");
        }
    }
}
