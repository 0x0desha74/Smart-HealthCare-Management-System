namespace CareFlow.Core.DTOs.Response
{
    public class ActionDoneSuccessfullyDto
    {
        public string Message { get; set; }
        public ActionDoneSuccessfullyDto(string message)
        {
            Message = message;
        }
    }
}
