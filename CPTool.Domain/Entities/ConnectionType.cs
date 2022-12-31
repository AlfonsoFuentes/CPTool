namespace CPTool.Domain.Entities
{
    public class ConnectionType : AuditableEntity
    {
        [ForeignKey("ConnectionTypeId")]
        public ICollection<Nozzle>? Nozzles { get; set; } = null!;



    }

}
