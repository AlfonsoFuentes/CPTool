

using CPTool.Entities;
using CPTool.Interfaces;

namespace CPTool.DTOS
{
   
    public  class AuditableEntityDTO : IAuditableEntityDTO ,IDisposable
    {
        public AuditableEntityDTO()
        {
            
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }=DateTime.Now;
        public virtual string? Name { get; set; } = "";

      
        public  List<AuditableEntityDTO> Details { get; set; }= new ();

      
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int? MasterId => Master?.Id;
        public AuditableEntityDTO? Master { get; set; }

        public bool Equals(IAuditableEntityDTO? other)
        {
            throw new NotImplementedException();
        }
    }





}
