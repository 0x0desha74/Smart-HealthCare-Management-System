namespace CareFlow.Core.DTOs.Response
{
    public class MedicineToReturnDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Manufacture { get; set; }
        public string Category { get; set; }
    }
}