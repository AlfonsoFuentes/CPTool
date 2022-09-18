

using CPTool.Interfaces;
using System.Linq.Expressions;

namespace CPTool.Entities
{
    public  class AuditableEntity : IAuditableEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; } = DateTime.UtcNow;
        public string? Name { get; set; } = "";
        public string? Description { get; set; } = "";





    }





}
