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
    }
}
