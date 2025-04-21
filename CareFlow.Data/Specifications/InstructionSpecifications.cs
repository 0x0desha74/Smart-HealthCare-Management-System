using CareFlow.Data.Entities;

namespace CareFlow.Core.Specifications
{
    public class InstructionSpecifications : BaseSpecification<Instruction>
    {
        public InstructionSpecifications(Guid prescriptionId, string userId)
            : base(i => i.PrescriptionId == prescriptionId && (i.Doctor.AppUserId == userId || i.Patient.AppUserId == userId))
        {
            

        }
        public InstructionSpecifications(Guid prescriptionId, Guid instructionId,string userId)
         : base(i => i.Id == instructionId && (i.Doctor.AppUserId == userId || i.Patient.AppUserId == userId))
        {


        }
    }
}
