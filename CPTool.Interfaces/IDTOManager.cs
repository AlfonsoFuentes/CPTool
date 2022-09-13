using System.Runtime.CompilerServices;

namespace CPTool.Interfaces
{
    public interface IDTOManager<TDTO, T>
        where TDTO : IAuditableEntityDTO
          where T : IAuditableEntity
    {


        List<TDTO> List { get; set; }
        Task<IResult<TDTO>> AddUpdate(IAuditableEntityDTO dto, CancellationToken cancellationToken);
        Task<IResult<int>> Delete(int id, CancellationToken cancellationToken);
        Task<IResult<int>> Delete(TDTO id, CancellationToken cancellationToken);
        Task<IResult<TDTO>> GetById(int id);
        Task UpdateList();
        Func<Task> PostUpdateListEvent { get; set; }
        Func<IAuditableEntityDTO,Task<IResult<IAuditableEntityDTO>>> PriorSave { get; set; }
        Func<IAuditableEntityDTO, Task<IResult<IAuditableEntityDTO>>> PostSave { get; set; }

    }
}
