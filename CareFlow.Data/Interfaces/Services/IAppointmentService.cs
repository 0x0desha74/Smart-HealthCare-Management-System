﻿using CareFlow.Core.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.Interfaces.Services
{
   public interface IAppointmentService
    {
        Task<AppointmentDto> AddAppointmentToPatient(Guid patientId, AppointmentDto appointmentDto);
    }
}
