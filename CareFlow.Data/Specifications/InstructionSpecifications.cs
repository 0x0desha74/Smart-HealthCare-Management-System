using CareFlow.Data.Entities;

namespace CareFlow.Core.Specifications
{
    public class InstructionSpecifications : BaseSpecification<Instruction>
    {
        public InstructionSpecifications(Guid prescriptionId)
            : base(i => i.PrescriptionId == prescriptionId)
        {


        }
        public InstructionSpecifications(Guid prescriptionId,Guid instructionId)
         : base(i => i.Id == instructionId)
        {


        }
    }
}
