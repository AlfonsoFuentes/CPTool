using AutoMapper;
using CPTool.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading;

namespace CPTool.Implementations
{
    //public class Delete<TDTO, T> : IDelete<TDTO, T>
    //   where TDTO : AuditableEntityDTO
    //   where T : AuditableEntity

    //{
    //    readonly IUnitOfWork _unitofwork;
    //    readonly IMapper _mapper;

    //    public Delete(IUnitOfWork unitofwork, IMapper mapper)
    //    {
    //        _unitofwork = unitofwork;
    //        _mapper = mapper;
    //    }




    //    public async Task<IResult<int>> Handle(int id, CancellationToken cancellationToken)
    //    {

    //        string retorno = "";
    //        var table = await _unitofwork.Repository<T>().GetByIdAsync(id);

    //        if (table != null)
    //        {
    //            retorno = $"{table.Name!} removed succesfully";
    //            await _unitofwork.Repository<T>().DeleteAsync(table);
    //            var result = await _unitofwork.CommitAndRemoveCache(cancellationToken, null);
    //            if(!result.Succeeded)
    //            {
    //                return await Result<int>.FailAsync("Not Delete!");
    //            }
    //            return await Result<int>.SuccessAsync(result.Data, retorno);
    //        }


    //        return await Result<int>.FailAsync("Not Found!");


    //    }

    //    public async Task<IResult<int>> Handle(TDTO dto, CancellationToken cancellationToken)
    //    {
    //        string retorno = "";
    //        var table = _mapper.Map<T>(dto);
    //        if (await _unitofwork.Repository<T>().AnyAsync(x=>x== table))
    //        {
               

    //            if (table != null)
    //            {
    //                retorno = $"{table.Name!} removed succesfully";
                  
    //                await _unitofwork.Repository<T>().DeleteAsync(table);
    //                var result = await _unitofwork.CommitAndRemoveCache(cancellationToken, null);
    //                if (!result.Succeeded)
    //                {
    //                    return await Result<int>.FailAsync("Not Delete!");
    //                }
    //                return await Result<int>.SuccessAsync(result.Data, retorno);
    //            }
    //        }
            


    //        return await Result<int>.FailAsync("Not Found!");
    //    }
    //}
}
