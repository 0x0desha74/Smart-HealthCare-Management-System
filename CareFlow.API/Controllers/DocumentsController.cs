using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
using CareFlow.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CareFlow.API.Controllers
{

    public class DocumentsController : BaseApiController
    {
        private readonly IDocumentService _documentService;

        public DocumentsController(IDocumentService documentService)
        {
            _documentService = documentService;
        }
        [Authorize(Roles = "Doctor,Patient")]
        [HttpPost]
        public async Task<ActionResult<string>> Create([FromForm] DocumentToUploadDto model)
        {
            var userId = User.FindFirstValue("uid");
            await _documentService.UploadDocumentAsync(model, userId);
            return "File uploaded successfully";
        }

        [Authorize(Roles = "Doctor,Patient")]
        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentToReturnDto>> GetDocument(Guid id)
        {
            var userId = User.FindFirstValue("uid");
            var document = await _documentService.GetDocumentAsync(id, userId);
            return Ok(document);
        }
    }
}
