
using CPTool.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CPTool.Implementations
{
    //public class CreateUpdate<TDTO, T> : ICreateUpdate<TDTO, T>
    //    where TDTO : IAuditableEntityDTO
    //    where T : IAuditableEntity

    //{
    //    readonly IUnitOfWork _unitofwork;



    //    readonly IMapper _mapper;

    //    public CreateUpdate(IUnitOfWork unitofwork
    //        , IMapper mapper)
    //    {
    //        _unitofwork = unitofwork;
    //        _mapper = mapper;
    //    }



    //    public async Task<IResult<TDTO>> Handle(TDTO dto, CancellationToken cancellationToken)
    //    {
    //        var table = _mapper.Map<T>(dto);

    //        var request = dto.Id == 0 ? await _unitofwork.Repository<T>().AddAsync(table) : _unitofwork.Repository<T>().UpdateAsync(table);
    //        var result = await _unitofwork.CommitAndRemoveCache(cancellationToken, null);
    //        if (!result.Succeeded)
    //            return await Result<TDTO>.FailAsync("Not Found!");

    //        dto = _mapper.Map<TDTO>(request);

    //        return await Result<TDTO>.SuccessAsync(dto, "Updated");
    //    }
    //}
}
