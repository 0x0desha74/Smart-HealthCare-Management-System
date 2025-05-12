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
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReviewService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ReviewToReturnDto> CreateAsync(ReviewToCreateDto dto,string userId)
        {
            var appointment = await _unitOfWork.Repository<Appointment>().GetEntityWithAsync(new AppointmentSpecifications(dto.AppointmentId))
                ?? throw new KeyNotFoundException("Appointment not found.");
            
            if (appointment.DoctorId != dto.DoctorId && appointment.Patient.AppUserId != userId)
                throw new UnauthorizedAccessException("You are not authorized.");


            var review = _mapper.Map<Review>(dto);
            review.PatientId = appointment.PatientId;
            await _unitOfWork.Repository<Review>().AddAsync(review);
            var result = await _unitOfWork.Complete();
            if (result <= 0)
                throw new InvalidOperationException("Failed to create review entity.");
            return _mapper.Map<ReviewToReturnDto>(review);
       
        }
    }
}
