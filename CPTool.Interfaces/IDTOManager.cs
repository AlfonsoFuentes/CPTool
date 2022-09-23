using System.Runtime.CompilerServices;

namespace CPTool.Interfaces
{
    public interface IDTOManager<TDTO, T>
        where TDTO : IAuditableEntityDTO
          where T : IAuditableEntity
    {

        TDTO CreateDTO();
        List<TDTO> List { get; set; }
        Task<IResult<IAuditableEntityDTO>> AddUpdate(IAuditableEntityDTO dto, CancellationToken cancellationToken);
        Task<IResult<IAuditableEntityDTO>> AddUpdate2(IAuditableEntityDTO dto, CancellationToken cancellationToken);
        Task<IResult<int>> Delete(int id, CancellationToken cancellationToken);
        Task<IResult<int>> Delete(TDTO id, CancellationToken cancellationToken);
        Task<TDTO> GetById(int id);
        Task GetList();
       
        Func<IAuditableEntityDTO,Task<IResult<IAuditableEntityDTO>>> PriorSave { get; set; }
        Func<IAuditableEntityDTO, Task<IResult<IAuditableEntityDTO>>> PostSave { get; set; }

    }
}
