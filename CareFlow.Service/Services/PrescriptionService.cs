using AutoMapper;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
using CareFlow.Core.Entities;
using CareFlow.Core.Interfaces;
using CareFlow.Core.Interfaces.Services;
using CareFlow.Core.Specifications;
using CareFlow.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Service.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IMedicalHistoryService _medicalHistoryService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PrescriptionService(IMedicalHistoryService medicalHistoryService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _medicalHistoryService = medicalHistoryService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PrescriptionToReturnDto> CreatePrescriptionAsync(PrescriptionToCreateDto dto)
        {
            var medicalHistoryDto = _mapper.Map<MedicalHistoryToCreateDto>(dto);
            var createdMedicalHistory = await _medicalHistoryService.CreateMedicalHistoryAsync(medicalHistoryDto);

            var prescription = _mapper.Map<Prescription>(dto);
            prescription.MedicalHistoryId = createdMedicalHistory.Id;

            var MedicalHistorySpec = new MedicineSpecifications(dto.MedicinesIds);
            var medicines = await _unitOfWork.Repository<Medicine>().GetAllWithSpecAsync(MedicalHistorySpec);
            if (medicines is null)
                throw new KeyNotFoundException("Medicines not found, Invalid medicines Ids provided");
            prescription.Medicines = medicines.ToList();


            await _unitOfWork.Repository<Prescription>().AddAsync(prescription);
            var result = await _unitOfWork.Complete();

            if(result <=0)
                throw new InvalidOperationException("An error occurred while creating prescription entity");

            var PrescriptionSpec = new PrescriptionSpecifications(createdMedicalHistory.Id);

            var createdPrescription = await _unitOfWork.Repository<Prescription>().GetEntityWithAsync(PrescriptionSpec);
            return _mapper.Map<PrescriptionToReturnDto>(createdPrescription);
        }
    }
}
