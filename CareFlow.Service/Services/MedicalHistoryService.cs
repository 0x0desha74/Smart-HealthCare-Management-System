using AutoMapper;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.Entities;
using CareFlow.Core.Interfaces;
using CareFlow.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Service.Services
{
    public class MedicalHistoryService : IMedicalHistoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MedicalHistoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MedicalHistory> CreateMedicalHistoryAsync(MedicalHistoryToCreateDto dto)
        {
            var medicalHistory = _mapper.Map<MedicalHistory>(dto);
            await _unitOfWork.Repository<MedicalHistory>().AddAsync(medicalHistory);
            var result = await _unitOfWork.Complete();

            if (result > 0)
                return medicalHistory;
            throw new InvalidOperationException("An error occurred while creating medial history entity");

        }
    }
}
