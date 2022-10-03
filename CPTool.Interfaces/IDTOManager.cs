using System.Runtime.CompilerServices;

namespace CPTool.Interfaces
{
    public interface IDTOManager<TDTO, T>
        where TDTO : IAuditableEntityDTO
          where T : IAuditableEntity
    {

       
      
        Task<IResult> AddUpdate(TDTO dto, CancellationToken cancellationToken);
        //Task<IResult<IAuditableEntityDTO>> AddUpdate2(IAuditableEntityDTO dto, CancellationToken cancellationToken);
        //Task<IResult<int>> Delete(int id, CancellationToken cancellationToken);
        Task<IResult> Delete(TDTO id, CancellationToken cancellationToken);
        Task<TDTO> GetById(int id);
        
       
       

    }
}
