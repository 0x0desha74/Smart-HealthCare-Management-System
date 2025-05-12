using AutoMapper;
using CareFlow.Core.DTOs.FilterDTOs;
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
         

            if ( appointment.Patient.AppUserId != userId)
                throw new UnauthorizedAccessException("You are not authorized to review this appointment.");


            var review = _mapper.Map<Review>(dto);
            review.PatientId = appointment.PatientId;
            review.DoctorId= appointment.DoctorId;
            await _unitOfWork.Repository<Review>().AddAsync(review);
            var result = await _unitOfWork.Complete();
            if (result <= 0)
                throw new InvalidOperationException("Failed to create review entity.");
            return _mapper.Map<ReviewToReturnDto>(review);
       
        }

        public async Task<ReviewToReturnDto> UpdateAsync(Guid id,ReviewToUpdateDto dto, string userId)
        {
            var review = await _unitOfWork.Repository<Review>().GetEntityWithAsync(new ReviewSpecifications(id,userId))
                ?? throw new KeyNotFoundException("Review not found.");

            review.Comment = dto.Comment;
            review.Rating = dto.Rating;
            _unitOfWork.Repository<Review>().Update(review);
            var result = await _unitOfWork.Complete();
            if (result <= 0)
                throw new InvalidOperationException("Failed to update review entity");
            return _mapper.Map<ReviewToReturnDto>(review);
        }




        public async Task<bool> DeleteAsync(Guid id, string userId) 
        {
            var review = await _unitOfWork.Repository<Review>().GetEntityWithAsync(new ReviewSpecifications(id, userId));

            if (review is null) return false;

            _unitOfWork.Repository<Review>().Delete(review);
            var result = await _unitOfWork.Complete();

            if (result > 0)
                return true;

            throw new InvalidOperationException("Failed to delete the review entity");
        }

        public async Task<Pagination<ReviewToReturnDto>> GetReviewsAsync(ReviewFilterDto specParams,Guid doctorId)
        {
            var reviews = await _unitOfWork.Repository<Review>().GetAllWithSpecAsync(new ReviewSpecifications(specParams,doctorId));

            if (!reviews.Any())
                throw new KeyNotFoundException("Reviews not found.");
            var count = await _unitOfWork.Repository<Review>().GetCountAsync(new ReviewWithFilterationForCountSpecifications(specParams, doctorId));
            var data = _mapper.Map<IReadOnlyList<ReviewToReturnDto>>(reviews);
            return new Pagination<ReviewToReturnDto>(specParams.PageSize, specParams.PageIndex, count, data);
        }
    }
}
