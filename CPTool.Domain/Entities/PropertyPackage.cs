namespace CPTool.Domain.Entities
{
    public class PropertyPackage : AuditableEntity
    {
        [ForeignKey("PropertyPackageId")]
        public ICollection<ProcessFluid>? ProcessFluids { get; set; } = null!;
    }
}
