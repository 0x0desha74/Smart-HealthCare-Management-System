using AutoMapper;
using CareFlow.Core.DTOs.Requests;
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
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppointmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AppointmentDto> AddAppointmentToPatient(Guid patientId, AppointmentDto appointmentDto)
        {
            var patient = await _unitOfWork.Repository<Patient>().GetByIdAsync(patientId);
            if (patient is null) return null;
            var appointment = _mapper.Map<Appointment>(appointmentDto);
            appointment.PatientId = patientId;
            await _unitOfWork.Repository<Appointment>().AddAsync(appointment);
            var result = await _unitOfWork.Complete();
            if (result > 0) return _mapper.Map<AppointmentDto>(appointment);
            throw new InvalidOperationException("An error occurred while adding the appointment to the patient");
        }
    }
}
