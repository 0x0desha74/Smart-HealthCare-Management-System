﻿using AutoMapper;
using CareFlow.Core.DTOs.FilterDTOs;
using CareFlow.Core.DTOs.Identity;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
using CareFlow.Core.Interfaces;
using CareFlow.Core.Interfaces.Services;
using CareFlow.Core.Specifications;
using CareFlow.Data.Entities;


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

        public async Task CreatePatientAsync(PatientRegisterDto patientDto, string userId)
        {
            var patient = _mapper.Map<Patient>(patientDto);
            patient.AppUserId = userId;
            await _unitOfWork.Repository<Patient>().AddAsync(patient);
            var result = await _unitOfWork.Complete();

            if (result <= 0)
                throw new InvalidOperationException("An error occurred while creating patient entity");
        }

        public async Task<Pagination<PatientToReturnDto>> GetPatientsAsync(PatientFilterDto specParams)
        {
            var spec = new PatientSpecifications(specParams);
            var patients = await _unitOfWork.Repository<Patient>().GetAllWithSpecAsync(spec);
            var count = await _unitOfWork.Repository<Patient>().GetCountAsync(new PatientWithFilterationForCountSpecifications(specParams));
            if (patients is null) return null;
            var data = _mapper.Map<IReadOnlyList<PatientToReturnDto>>(patients);
            return new Pagination<PatientToReturnDto>(specParams.PageSize, specParams.PageIndex, count, data);
        }


        public async Task<PatientToReturnDto> GetPatientAsync(Guid id)
        {
            var spec = new PatientSpecifications(id);
            var patient = await _unitOfWork.Repository<Patient>().GetEntityWithAsync(spec);
            if (patient is null) return null;
            return _mapper.Map<Patient, PatientToReturnDto>(patient);

        }




        public async Task<bool> DeletePatientAsync(Guid id)
        {
            var patient = await _unitOfWork.Repository<Patient>().GetByIdAsync(id);
            if (patient is null) return false;
            _unitOfWork.Repository<Patient>().Delete(patient);
            var result = await _unitOfWork.Complete();
            return result > 0;
        }


        public async Task<PatientToReturnDto> UpdatePatientAsync(PatientDto patientDto)
        {
            if (patientDto is null || patientDto.id == Guid.Empty)
                throw new KeyNotFoundException("Invalid patient data");

            var existingPatient = await _unitOfWork.Repository<Patient>().GetByIdAsync(patientDto.id);
            if (existingPatient is null) throw new KeyNotFoundException("Patient not found");

            _mapper.Map(patientDto, existingPatient);

            _unitOfWork.Repository<Patient>().Update(existingPatient);

            var result = await _unitOfWork.Complete();

            if (result > 0)
                return _mapper.Map<Patient, PatientToReturnDto>(existingPatient);
            else
                throw new InvalidOperationException("An error occurred while update");

        }

        //public async Task<Pagination<AppointmentToReturnDto>> GetAppointmentsOfPatientAsync(PatientFilterDto specParams, string userId)
        //{
        //    var spec = new AppointmentsPatientSpecifications(specParams, userId);
        //    var appointments = await _unitOfWork.Repository<Appointment>().GetAllWithSpecAsync(spec);
        //    if (appointments is null) return null;

        //    var count = await _unitOfWork.Repository<Appointment>().GetCountAsync(spec);

        //    var data = _mapper.Map<IReadOnlyList<AppointmentToReturnDto>>(appointments);
        //    return new Pagination<AppointmentToReturnDto>(specParams.PageSize, specParams.PageIndex, count, data);
        //}

        public async Task<AppointmentDetailsDto> GetAppointmentOfPatientAsync(Guid appointmentId, string userId)
        {
            var spec = new AppointmentsPatientSpecifications(appointmentId, userId);
            var appointment = await _unitOfWork.Repository<Appointment>().GetEntityWithAsync(spec);

            if (appointment is null)
                return null;

            return _mapper.Map<AppointmentDetailsDto>(appointment);
        }

        public async Task<Pagination<AppointmentToReturnDto>> GetUpcomingAppointmentsOfPatientAsync(PaginationDto specParams, string userId)
        {
            var spec = new UpcomingPatientAppointmentSpecifications(specParams, userId);
            var appointments = await _unitOfWork.Repository<Appointment>().GetAllWithSpecAsync(spec);

            if (appointments is null)
                return null;

            var count = await _unitOfWork.Repository<Appointment>().GetCountAsync(new AppointmentWithFilterationForCountSpecification(userId));

            var data = _mapper.Map<IReadOnlyList<AppointmentToReturnDto>>(appointments);
            return new Pagination<AppointmentToReturnDto>(specParams.PageSize, specParams.PageIndex, count, data);
        }
    }
}
