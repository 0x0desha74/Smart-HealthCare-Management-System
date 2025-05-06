using AutoMapper;
using CareFlow.Core.DTOs.FilterDTOs;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
using CareFlow.Core.Interfaces;
using CareFlow.Core.Interfaces.Services;
using CareFlow.Core.Specifications;
using CareFlow.Data.Entities;

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

        public async Task<Pagination<ClinicToReturnDto>> GetClinics(ClinicFilterDto specParams)
        {
            var spec = new ClinicSpecifications(specParams);
            var clinics = await _unitOfWork.Repository<Clinic>().GetAllWithSpecAsync(spec);
            if (clinics is null) return null;
            var count = await _unitOfWork.Repository<Clinic>().GetCountAsync(new ClinicFilterationForCountSpecification(specParams));
            var data = _mapper.Map<IReadOnlyList<ClinicToReturnDto>>(clinics);
            return new Pagination<ClinicToReturnDto>(specParams.PageSize, specParams.PageIndex, count, data);
        }

        public async Task<ClinicToReturnDto> GetClinic(Guid id)
        {
            var spec = new ClinicSpecifications(id);
            var clinic = await _unitOfWork.Repository<Clinic>().GetEntityWithAsync(spec);
            if (clinic is null) return null;
            return _mapper.Map<ClinicToReturnDto>(clinic);
        }


        public async Task<ClinicDto> CreateClinicAsync(ClinicDto clinicDto)
        {
            if (clinicDto is null || clinicDto.Id != Guid.Empty)
                throw new ArgumentException("Invalid clinic data provided.");

            var clinic = _mapper.Map<Clinic>(clinicDto);



            await _unitOfWork.Repository<Clinic>().AddAsync(clinic);
            //clinic.Location.ClinicId = clinic.Id;
            var result = await _unitOfWork.Complete();

            if (result > 0) return _mapper.Map<ClinicDto>(clinic);
            throw new InvalidOperationException("An error occurred while creating clinic entity.");
        }

        public async Task<bool> DeleteClinic(Guid id)
        {
            var spec = new ClinicSpecifications(id);
            var clinic = await _unitOfWork.Repository<Clinic>().GetEntityWithAsync(spec);
            if (clinic is null) return false;
            _unitOfWork.Repository<Clinic>().Delete(clinic);
            _unitOfWork.Repository<Location>().Delete(clinic.Location);

            var result = await _unitOfWork.Complete();
            return result > 0 ? true : throw new InvalidOperationException("An error occurred while deleting the clinic entity.");

        }

        public async Task<ClinicToReturnDto> UpdateClinicAsync(ClinicDto clinicDto)
        {
            if (clinicDto.Id == Guid.Empty)
                throw new ArgumentException("Clinic ID must not be null.");

            if (clinicDto.location.Id == Guid.Empty)
                throw new ArgumentException("Location ID must not be null.");

            var spec = new ClinicSpecifications(clinicDto.Id);
            var existingClinic = await _unitOfWork.Repository<Clinic>().GetEntityWithAsync(spec);

            if (existingClinic is null)
                throw new KeyNotFoundException("Invalid clinic id provided.");

            _mapper.Map(clinicDto, existingClinic);

            _unitOfWork.Repository<Clinic>().Update(existingClinic);
            var result = await _unitOfWork.Complete();
            if (result <= 0) throw new InvalidOperationException("An error occurred while updating the entity.");
            return _mapper.Map<ClinicToReturnDto>(existingClinic);
        }
    }
}
