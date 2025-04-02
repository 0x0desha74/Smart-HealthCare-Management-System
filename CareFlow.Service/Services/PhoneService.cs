using AutoMapper;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
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
    public class PhoneService : IPhoneService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PhoneService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

        public Task<bool> DeletePhone(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PhoneToReturnDto> GetPhone(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<PhoneToReturnDto>> GetPhones()
        {
            throw new NotImplementedException();
        }

        public Task<PhoneToReturnDto> UpdatePhone(PhoneDto phoneDto)
        {
            throw new NotImplementedException();
        }
    }
}
