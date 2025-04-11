using AutoMapper;
using CareFlow.Core.DTOs.Requests;
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
    public class ClinicService : IClinicService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClinicService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ClinicToReturnDto>> GetClinics()
        {
            var spec = new ClinicSpecifications();
            var clinics = await _unitOfWork.Repository<Clinic>().GetAllWithSpecAsync(spec);
            if (clinics is null) return null;
            return _mapper.Map<IReadOnlyList<ClinicToReturnDto>>(clinics);
        }



        public async Task<ClinicDto> CreateClinicAsync(ClinicDto clinicDto)
        {
            if (clinicDto is null || clinicDto.Id != Guid.Empty)
                throw new ArgumentException("Invalid clinic data provided.");

            var clinic = _mapper.Map<Clinic>(clinicDto);

            var location = _mapper.Map<Location>(clinicDto.location);
            await _unitOfWork.Repository<Location>().AddAsync(location);
            var locationResult = await _unitOfWork.Complete();
            if (locationResult <= 0)
                throw new InvalidOperationException("An error occurred while creating location.");

            clinic.LocationId = location.Id;

            await _unitOfWork.Repository<Clinic>().AddAsync(clinic);

            var result = await _unitOfWork.Complete();

            if (result > 0) return _mapper.Map<ClinicDto>(clinic);
            throw new InvalidOperationException("An error occurred while creating clinic entity.");
        }


    }
}
