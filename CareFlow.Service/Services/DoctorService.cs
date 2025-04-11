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
    public class DoctorService : IDoctorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DoctorService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        public async Task<IReadOnlyList<DoctorToReturnDto>> GetDoctorsAsync()
        {
            var spec = new DoctorSpecifications();
            var doctors = await _unitOfWork.Repository<Doctor>().GetAllWithSpecAsync(spec);
            if (doctors is null) return null;
            return _mapper.Map<IReadOnlyList<DoctorToReturnDto>>(doctors);

        }


        public async Task<DoctorToReturnDto> GetDoctorAsync(Guid id)
        {
            var spec = new DoctorSpecifications(id);
            var doctor = await _unitOfWork.Repository<Doctor>().GetEntityWithAsync(spec);
            if (doctor is null)
                return null;
            return _mapper.Map<DoctorToReturnDto>(doctor);
        }



        public async Task<DoctorToReturnDto> CreateDoctorAsync(DoctorDto doctorDto)
        {
            if (doctorDto.Id != Guid.Empty)
                throw new ArgumentException("Invalid doctor data provided");

            var spec = new SpecializationSpecifications(doctorDto.SpecializationsIds);
            var specializations = await _unitOfWork.Repository<Specialization>().GetAllWithSpecAsync(spec);

            if (specializations.Count != doctorDto.SpecializationsIds.Count)
                throw new KeyNotFoundException("One or more specialization id are not valid");

            var doctor = _mapper.Map<Doctor>(doctorDto);

            doctor.Specializations = specializations.ToList();

            await _unitOfWork.Repository<Doctor>().AddAsync(doctor);
            var result = await _unitOfWork.Complete();

            if (result <= 0)
                throw new InvalidOperationException("An error occurred while creating doctor entity");

            return _mapper.Map<DoctorToReturnDto>(doctor);
        }

        public async Task<DoctorToReturnDto> UpdateDoctorAsync(DoctorDto doctorDto)
        {
            if (doctorDto.Id == Guid.Empty)
                throw new ArgumentException("Doctor ID must not be null");

            var spec = new DoctorSpecifications(doctorDto.Id);
            var existingDoctor = await _unitOfWork.Repository<Doctor>().GetEntityWithAsync(spec);

            if (existingDoctor is null) return null;

            _mapper.Map(doctorDto, existingDoctor);

            var specializationSpec = new SpecializationSpecifications(doctorDto.SpecializationsIds);
            var specializations = await _unitOfWork.Repository<Specialization>().GetAllWithSpecAsync(specializationSpec);

            existingDoctor.Specializations.Clear();

            foreach(var specialization in specializations)
            {
                existingDoctor.Specializations.Add(specialization);
            }

            _unitOfWork.Repository<Doctor>().Update(existingDoctor);
            var result = await _unitOfWork.Complete();

            if (result <= 0)
                throw new InvalidOperationException("An error occurred while updating the entity");

            return _mapper.Map<DoctorToReturnDto>(existingDoctor);
        }

        public Task<bool> DeleteDoctorAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
