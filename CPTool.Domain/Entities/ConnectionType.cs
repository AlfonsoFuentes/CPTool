namespace CPTool.Domain.Entities
{
    public class ConnectionType  : BaseDomainModel
    {
        public ICollection<Nozzle>? Nozzles { get; set; } = null!;
    }

}
