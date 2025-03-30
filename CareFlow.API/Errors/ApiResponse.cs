
namespace CareFlow.API.Errors
{
    public class ApiResponse
    {

        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public ApiResponse(int statusCode, string? message)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string? GetDefaultMessageForStatusCode(int StatusCode)
        {
            return StatusCode switch
            {
                400 => "A bad request, you have made.",
                404 => "Resource was not found.",
                401 => "Authorized!, you are not.",
                500 => "Errors are the path to the dark side. Errors lead to anger, anger leads to hate, hate leads to career change.",
                _ => null
            };
        }
    }
}
