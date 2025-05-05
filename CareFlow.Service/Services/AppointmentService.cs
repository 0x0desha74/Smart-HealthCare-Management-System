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
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppointmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }




        public async Task<AppointmentDetailsDto> GetAppointmentAsync(Guid id,string userId)
        {
            var spec = new AppointmentSpecifications(id);
            var appointment = await _unitOfWork.Repository<Appointment>().GetEntityWithAsync(spec);

            if (appointment is null)
                throw new KeyNotFoundException("Appointment not found, Invalid appointment ID");

            if (appointment.Doctor.AppUserId != userId && appointment.Patient.AppUserId != userId)
                throw new UnauthorizedAccessException("You are not authorized to view this appointment.");
                
                    return _mapper.Map<AppointmentDetailsDto>(appointment);
        }


        public async Task<Pagination<AppointmentToReturnDto>> GetAppointmentsAsync(AppointmentFilterDto specParams, string userId)
        {
            var spec = new AppointmentSpecifications(specParams, userId);
            var appointments = await _unitOfWork.Repository<Appointment>().GetAllWithSpecAsync(spec);
            if (!appointments.Any()) return null;

            var count = await _unitOfWork.Repository<Appointment>().GetCountAsync(new AppointmentWithFilterationForCountSpecification(specParams, userId));
            var data = _mapper.Map<IReadOnlyList<AppointmentToReturnDto>>(appointments);
            return new Pagination<AppointmentToReturnDto>(specParams.PageSize, specParams.PageIndex, count, data);
        }





        public async Task<AppointmentToReturnDto> CreateAppointmentAsync(AppointmentCreateDto appointmentDto)
        {

            var patient = await _unitOfWork.Repository<Patient>().GetByIdAsync(appointmentDto.PatientId);
            if (patient is null)
                throw new KeyNotFoundException("Patient not found, Invalid patient ID");

            var clinic = await _unitOfWork.Repository<Clinic>().GetByIdAsync(appointmentDto.ClinicId);
            if (clinic is null)
                throw new KeyNotFoundException("Clinic not found, Invalid clinic ID");

            var doctor = await _unitOfWork.Repository<Doctor>().GetByIdAsync(appointmentDto.DoctorId);
            if (doctor is null)
                throw new KeyNotFoundException("Doctor not found, Invalid doctor ID");

            var appointment = _mapper.Map<Appointment>(appointmentDto);

            await _unitOfWork.Repository<Appointment>().AddAsync(appointment);
            var result = await _unitOfWork.Complete();

            if (result <= 0)
                throw new InvalidOperationException("An error occurred while creating appointment entity");

            return _mapper.Map<AppointmentToReturnDto>(appointment);


        }

        public async Task<AppointmentToReturnDto> UpdateAppointmentAsync(AppointmentUpdateDto appointmentDto,string userId)
        {
            if (appointmentDto.Id == Guid.Empty)
                throw new ArgumentException("Invalid appointment data provided, Id must no not be null");

            var spec = new AppointmentSpecifications(appointmentDto.Id);
            var existingAppointment = await _unitOfWork.Repository<Appointment>().GetEntityWithAsync(spec);

            if (existingAppointment is null)
                throw new KeyNotFoundException("Appointment not found, Invalid appointment Id provided");

            if (existingAppointment.Doctor.AppUserId != userId && existingAppointment.Patient.AppUserId != userId)
                throw new UnauthorizedAccessException("You are not authorized to view this appointment.");

            var doctor = await _unitOfWork.Repository<Doctor>().GetByIdAsync(appointmentDto.DoctorId);

            if (doctor is null)
                throw new KeyNotFoundException("Doctor not found, Invalid doctor Id provided");

            var clinic = await _unitOfWork.Repository<Clinic>().GetByIdAsync(appointmentDto.ClinicId);

            if (clinic is null)
                throw new KeyNotFoundException("Clinic not found, Invalid clinic Id provided");

            _mapper.Map(appointmentDto, existingAppointment);

            _unitOfWork.Repository<Appointment>().Update(existingAppointment);
            var result = await _unitOfWork.Complete();

            if (result <= 0)
                throw new InvalidOperationException("An error occurred while updating the appointment entity");
            return _mapper.Map<AppointmentToReturnDto>(existingAppointment);
        }

        public async Task<bool> DeleteAppointmentAsync(Guid id,string userId)
        {
            var spec = new AppointmentSpecifications(id);
            var appointment = await _unitOfWork.Repository<Appointment>().GetEntityWithAsync(spec);

            if (appointment is null)
                return false;

            if (appointment.Doctor.AppUserId != userId && appointment.Patient.AppUserId != userId)
                throw new UnauthorizedAccessException("You are not authorized to view this appointment.");

            _unitOfWork.Repository<Appointment>().Delete(appointment);
            var result = await _unitOfWork.Complete();

            return result > 0 ? true : throw new InvalidOperationException("An error occurred while deleting appointment entity");

        }
    }
}
