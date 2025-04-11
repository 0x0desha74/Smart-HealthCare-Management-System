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
    public class SpecializationService : ISpecializationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SpecializationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<IReadOnlyList<SpecializationDto>> GetSpecializationsAsync()
        {
            var specializations = await _unitOfWork.Repository<Specialization>().GetAllAsync();
            if(specializations is null) return null;
            return _mapper.Map<IReadOnlyList<SpecializationDto>>(specializations);

        }



        public async Task<SpecializationDto> GetSpecializationAsync(Guid id)
        {
            var specialization = await _unitOfWork.Repository<Specialization>().GetByIdAsync(id);
            if (specialization is null) return null;
            return _mapper.Map<SpecializationDto>(specialization);
        }



        public async Task CreateSpecializationAsync(SpecializationDto specializationDto)
        {
            if (specializationDto.Id != Guid.Empty)
                throw new Exception("Invalid Data Provided, Id should be null");
            var specialization = _mapper.Map<Specialization>(specializationDto);
            await _unitOfWork.Repository<Specialization>().AddAsync(specialization);
            var result = await _unitOfWork.Complete();
            if (result <= 0) throw new InvalidOperationException("An error occurred while creating specialization");
        }

        public async Task<SpecializationDto> UpdateSpecializationAsync(SpecializationDto specializationDto)
        {
            if (specializationDto is null || specializationDto.Id == Guid.Empty)
                throw new ArgumentException("Specialization data is not valid");

            var existingSpec = await _unitOfWork.Repository<Specialization>().GetByIdAsync(specializationDto.Id);
            if (existingSpec is null)
                return null;

            _mapper.Map(specializationDto, existingSpec);
            _unitOfWork.Repository<Specialization>().Update(existingSpec);
            var result = await _unitOfWork.Complete();
            if (result > 0) return _mapper.Map<SpecializationDto>(existingSpec);
            throw new InvalidOperationException("An error occurred while updating");

        }

        public async Task<bool> DeleteSpecializationAsync(Guid id)
        {
            var specialization = await _unitOfWork.Repository<Specialization>().GetByIdAsync(id);
            if (specialization is null)
                throw new KeyNotFoundException("Invalid Specialization Id");
            _unitOfWork.Repository<Specialization>().Delete(specialization);
            var result = await _unitOfWork.Complete();
            return result > 0;
        }
    }
}
