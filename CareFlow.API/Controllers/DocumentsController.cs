using CareFlow.API.Errors;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
using CareFlow.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<DocumentToReturnDto>>> GetDocuments()
        {
            var userId = User.FindFirstValue("uid");
            var documents = await _documentService.GetDocumentsForPatientAsync(userId);
            return Ok(documents);

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

        [Authorize(Roles = "Doctor,Patient")]
        [HttpPut("{id}")]
        public async Task<ActionResult<string>> Update(Guid id, [FromBody] DocumentToUpdateDto model)
        {
            await _documentService.UpdateDocumentAsync(id, model, User.FindFirstValue("uid"));
            return Ok("Document Updated Successfully.");
        }


        [Authorize(Roles = "Doctor,Patient")]
        [HttpGet("download/{id}")]
        public async Task<IActionResult> DownloadDocumentAsync(Guid id)
        {
            var userId = User.FindFirstValue("uid");
            var (fileData, contentType, fileName) = await _documentService.DownloadDocumentAsync(id, userId);
            return File(fileData, contentType, fileName);
        }



        [Authorize(Roles = "Doctor,Patient")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var isDeleted = await _documentService.DeleteDocumentAsync(id, User.FindFirstValue("uid"));

            if (!isDeleted)
                return NotFound(new ApiResponse(404, "Document not found."));
            return NoContent();
        }





    }
}
