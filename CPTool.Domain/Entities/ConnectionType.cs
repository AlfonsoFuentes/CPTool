namespace CPTool.Domain.Entities
{
    public class ConnectionType : BaseDomainModel
    {
        [ForeignKey("ConnectionTypeId")]
        public ICollection<Nozzle>? Nozzles { get; set; } = null!;



    }

}
