

using CPTool.Entities;
using CPTool.Interfaces;

namespace CPTool.DTOS
{

    public  class AuditableEntityDTO : IAuditableEntityDTO, IDisposable
    {
        public AuditableEntityDTO()
        {

        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;
        public virtual string? Name { get; set; } = "";

      


        public void Dispose()
        {
            throw new NotImplementedException();
        }

       

        public bool Equals(IAuditableEntityDTO? other)
        {
            throw new NotImplementedException();
        }

        public string? Description { get; set; }
        public List<AuditableEntityDTO> Details { get; set; } = new();
        public AuditableEntityDTO? Master { get; set; }
    }





}
