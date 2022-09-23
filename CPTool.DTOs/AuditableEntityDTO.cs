

using AutoMapper;
using CPTool.Entities;
using CPTool.Interfaces;

namespace CPTool.DTOS
{

    public  class AuditableEntityDTO : IAuditableEntityDTO, IDisposable, IMapFrom<AuditableEntity>
    {
        public AuditableEntityDTO()
        {

        }
       

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;
        public virtual string? Name { get; set; } = "";

      


        public virtual void Dispose()
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
        public Func<IAuditableEntityDTO, IAuditableEntityDTO>? TransferDataToObject { get; set; }
        public Func<IAuditableEntityDTO, CancellationToken, Task<IResult<IAuditableEntityDTO>>>? SaveObject { get; set; }

        public virtual void OnSubscribeTransferData()
        {
            throw new NotImplementedException();
        }
    }





}
