namespace CPTool.Interfaces
{
    public interface IAuditableEntity
    {
        public int Id { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime? UpdatedDate { get; set; }
        string? Name { get; set; }

       
    }

}
