﻿using CareFlow.Core.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.Interfaces.Services
{
   public interface ISpecializationService
    {
        Task<IReadOnlyList<SpecializationDto>> GetSpecializationsAsync();
        Task<SpecializationDto> GetSpecializationAsync(Guid id);
        Task CreateSpecializationAsync(SpecializationDto specializationDto);
        Task<SpecializationDto> UpdateSpecializationAsync(SpecializationDto specializationDto);
        Task<bool> DeleteSpecializationAsync(Guid id);
        
    }
}
