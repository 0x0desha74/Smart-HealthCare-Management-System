using AutoMapper;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
using CareFlow.Core.Interfaces;
using CareFlow.Core.Interfaces.Services;
using CareFlow.Data.Entities;

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


        public async Task<IReadOnlyList<MedicineToReturnDto>> GetMedicinesAsync()
        {
            var medicines = await _unitOfWork.Repository<Medicine>().GetAllAsync();
            if (!medicines.Any())
                return null;
            return _mapper.Map<IReadOnlyList<MedicineToReturnDto>>(medicines);
        }

        public async Task<MedicineToReturnDto> GetMedicineAsync(Guid id)
        {
            var medicine = await _unitOfWork.Repository<Medicine>().GetByIdAsync(id);
            if (medicine is null)
                return null;
            return _mapper.Map<MedicineToReturnDto>(medicine);
        }


        public async Task<MedicineToReturnDto> CreateMedicineAsync(MedicineToCreateDto dto)
        {
            var medicine = _mapper.Map<Medicine>(dto);
            await _unitOfWork.Repository<Medicine>().AddAsync(medicine);
            var result = await _unitOfWork.Complete();

            if (result > 0)
                return _mapper.Map<MedicineToReturnDto>(medicine);
            throw new InvalidOperationException("An error occurred while creating medicine entity");
        }



        public async Task<MedicineToReturnDto> UpdateMedicineAsync(MedicineToUpdateDto dto)
        {
            var existingMedicine = await _unitOfWork.Repository<Medicine>().GetByIdAsync(dto.Id);
            if (existingMedicine is null)
                throw new KeyNotFoundException("Medicine not found, Invalid medicine ID provided");
            _mapper.Map(dto, existingMedicine);

            _unitOfWork.Repository<Medicine>().Update(existingMedicine);
            var result = await _unitOfWork.Complete();
            if (result > 0)
                return _mapper.Map<MedicineToReturnDto>(existingMedicine);
            throw new InvalidOperationException("An error occurred while updating the medicine entity");

        }

        public async Task<bool> DeleteMedicineAsync(Guid id)
        {
            var medicine = await _unitOfWork.Repository<Medicine>().GetByIdAsync(id);
            if (medicine is null)
                return false;

            _unitOfWork.Repository<Medicine>().Delete(medicine);
            var result = await _unitOfWork.Complete();

            return result > 0 ? true :
                 throw new InvalidOperationException("An error occurred while deleting medicine entity");

        }
    }
}
