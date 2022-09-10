

using CPTool.Interfaces;
using System.Linq.Expressions;

namespace CPTool.Entities
{
    public  class AuditableEntity : IAuditableEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? Name { get; set; } = "";

        


    }





}
