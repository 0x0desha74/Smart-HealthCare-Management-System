using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.Entities.Enums
{
    public enum MedicalHistoryStatus
    {
        Active, //Currently being treated
        Resolved, //successfully treated
        Chronic, //Ongoing management
        Recurring //Condition that comes and goes

    }
}
