using CareFlow.Data.Entities;

namespace CareFlow.Core.Specifications
{
    public class MedicineSpecifications : BaseSpecification<Medicine>
    {
        public MedicineSpecifications(List<Guid> medicineIds) : base(m => medicineIds.Contains(m.Id))
        {

        }
    }
}
