namespace CPTool.Domain.Entities
{
    public class PropertyPackage : BaseDomainModel
    {
        [ForeignKey("PropertyPackageId")]
        public ICollection<ProcessFluid>? ProcessFluids { get; set; } = null!;
    }
}
