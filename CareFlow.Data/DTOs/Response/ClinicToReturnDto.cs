using CareFlow.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.DTOs.Response
{
    public class ClinicToReturnDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TimeOnly OpeningTime { get; set; }
        public TimeOnly ClosingTime { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public bool IsOpen24Hours { get; set; }
        public LocationToReturnDto Location { get; set; }
    }
}
