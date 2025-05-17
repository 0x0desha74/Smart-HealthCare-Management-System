using CareFlow.Core.DTOs.FilterDTOs;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;

namespace CareFlow.Core.Interfaces.Services
{
    public interface IReviewService
    {
        Task<ReviewToReturnDto> CreateAsync(ReviewToCreateDto dto, string userId);
        Task<ReviewToReturnDto> UpdateAsync(Guid id, ReviewToUpdateDto dto, string userId);
        Task<bool> DeleteAsync(Guid id, string userId);
        Task<Pagination<ReviewToReturnDto>> GetReviewsAsync(ReviewFilterDto specParams, Guid doctorId);
    }
}

