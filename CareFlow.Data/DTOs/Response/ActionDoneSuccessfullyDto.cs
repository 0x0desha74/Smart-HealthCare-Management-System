using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
