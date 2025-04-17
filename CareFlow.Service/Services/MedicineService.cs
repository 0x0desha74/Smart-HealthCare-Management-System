using AutoMapper;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
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
    public class MedicineService : IMedicineService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MedicineService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MedicineToReturnDto> CreateMedicineAsync(MedicineToCreateDto dto)
        {
            var medicine = _mapper.Map<Medicine>(dto);
            await _unitOfWork.Repository<Medicine>().AddAsync(medicine);
            var result =await _unitOfWork.Complete();

            if (result > 0)
                return _mapper.Map<MedicineToReturnDto>(medicine);
            throw new InvalidOperationException("An error occurred while creating medicine entity");
        }
    }
}
