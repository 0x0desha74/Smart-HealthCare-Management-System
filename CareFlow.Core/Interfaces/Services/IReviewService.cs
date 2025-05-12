using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.Interfaces.Services
{
   public interface IReviewService
    {
        Task<ReviewToReturnDto> CreateAsync(ReviewToCreateDto dto ,string userId);
        Task<ReviewToReturnDto> UpdateAsync(Guid id,ReviewToUpdateDto dto, string userId);
        Task<bool> DeleteAsync(Guid id, string userId);
    }
}

