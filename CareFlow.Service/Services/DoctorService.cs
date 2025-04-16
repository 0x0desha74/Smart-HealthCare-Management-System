using AutoMapper;
using CareFlow.Core.DTOs.Identity;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
using CareFlow.Core.Interfaces;
using CareFlow.Core.Interfaces.Services;
using CareFlow.Core.Specifications;
using CareFlow.Data.Entities;

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



        public async Task CreateDoctorAsync(DoctorRegisterDto doctorDto, string userId)
        {

            var spec = new SpecializationSpecifications(doctorDto.SpecializationsIds);
            var specializations = await _unitOfWork.Repository<Specialization>().GetAllWithSpecAsync(spec);

            if (specializations.Count != doctorDto.SpecializationsIds.Count)
                throw new KeyNotFoundException("One or more specialization id are not valid");

            var doctor = _mapper.Map<Doctor>(doctorDto);

            doctor.Specializations = specializations.ToList();
            doctor.AppUserId = userId;
            await _unitOfWork.Repository<Doctor>().AddAsync(doctor);
            var result = await _unitOfWork.Complete();

            if (result <= 0)
                throw new InvalidOperationException("An error occurred while creating doctor entity");

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

            foreach (var specialization in specializations)
            {
                existingDoctor.Specializations.Add(specialization);
            }

            _unitOfWork.Repository<Doctor>().Update(existingDoctor);
            var result = await _unitOfWork.Complete();

            if (result <= 0)
                throw new InvalidOperationException("An error occurred while updating the entity");

            return _mapper.Map<DoctorToReturnDto>(existingDoctor);
        }

        public async Task<bool> DeleteDoctorAsync(Guid id)
        {
            var spec = new DoctorSpecifications(id);
            var doctor = await _unitOfWork.Repository<Doctor>().GetEntityWithAsync(spec);
            if (doctor is null) return false;
            _unitOfWork.Repository<Doctor>().Delete(doctor);
            var result = await _unitOfWork.Complete();
            return result > 0 ? true : throw new InvalidOperationException("An error occurred while deleting doctor entity");
        }

        public async Task<IReadOnlyList<AppointmentToReturnDto>> GetAppointmentsOfDoctor(string userId)
        {
            var spec = new AppointmentsDoctorSpecifications(userId);
            var appointments = await _unitOfWork.Repository<Appointment>().GetAllWithSpecAsync(spec);
            if (appointments is null)
                return null;
            return _mapper.Map<IReadOnlyList<AppointmentToReturnDto>>(appointments);
        }

        public async Task<AppointmentToReturnDto> GetAppointmentOfDoctor(Guid appointmentId, string userId)
        {
            var spec = new AppointmentsDoctorSpecifications(appointmentId, userId);
            var appointment = await _unitOfWork.Repository<Appointment>().GetEntityWithAsync(spec);

            if (appointment is null)
                return null;

            return _mapper.Map<AppointmentToReturnDto>(appointment);
        }

        public async Task<IReadOnlyList<AppointmentToReturnDto>> GetUpcomingAppointmentOfDoctor(string userId)
        {
            var spec = new UpcomingPatientAppointmentsSpecifications(userId);
            var appointments = await _unitOfWork.Repository<Appointment>().GetAllWithSpecAsync(spec);
            if (appointments is null)
                return null;
            return _mapper.Map<IReadOnlyList<AppointmentToReturnDto>>(appointments);
        }
    }
}
