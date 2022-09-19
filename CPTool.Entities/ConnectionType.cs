

namespace CPTool.Entities
{
    public class ConnectionType : AuditableEntity
    {
        public ICollection<Nozzle>? Nozzles { get; set; } = null!;
    }

}
