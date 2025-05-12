using CareFlow.API.Errors;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
using CareFlow.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CareFlow.API.Controllers
{

    public class ReviewsController : BaseApiController
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [Authorize(Roles = "Patient")]
        [HttpPost]
        public async Task<ActionResult<ReviewToReturnDto>> Create([FromBody] ReviewToCreateDto model)
        {
            var review = await _reviewService.CreateAsync(model, User.FindFirstValue("uid"));
            return Ok(review);
        }

        [Authorize(Roles = "Patient")]
        [HttpPut("{id}")]
        public async Task<ActionResult<ReviewToReturnDto>> Update(Guid id, ReviewToUpdateDto model)
        {
            var review = await _reviewService.UpdateAsync(id, model, User.FindFirstValue("uid"));
            return Ok(review);
        }

        [Authorize(Roles="Patient")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var isDeleted = await _reviewService.DeleteAsync(id, User.FindFirstValue("uid"));
            if (!isDeleted)
                return NotFound(new ApiResponse(404, "Review not found."));
            return NoContent();
        }
    }
}
