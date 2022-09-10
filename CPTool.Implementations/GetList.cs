using AutoMapper;
using CPTool.Interfaces;

namespace CPTool.Implementations
{
    //public class GetList<TDTO, T> : IGetList<TDTO, T>
    //   where TDTO : IAuditableEntityDTO
    //   where T : IAuditableEntity

    //{
    //    readonly IUnitOfWork _unitofwork;
    //    readonly IMapper _mapper;

    //    public GetList(IUnitOfWork unitofwork, IMapper mapper)
    //    {
    //        _unitofwork = unitofwork;
    //        _mapper=mapper;
    //    }



    //    public async Task<IResult<List<TDTO>>> Handle()
    //    {
    //        var list = await _unitofwork.Repository<T>().GetAllAsync();

    //        var ListDTO = _mapper.Map<List<TDTO>>(list);

    //        return await Result<List<TDTO>>.SuccessAsync(ListDTO, "List returned");
    //    }
    //}
}
