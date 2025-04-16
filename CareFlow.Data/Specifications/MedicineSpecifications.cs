using CareFlow.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.Specifications
{
   public class MedicineSpecifications:BaseSpecification<Medicine>
    {
        public MedicineSpecifications(List<Guid> medicineIds):base(m=> medicineIds.Contains(m.Id))
        {

        }
    }
}
