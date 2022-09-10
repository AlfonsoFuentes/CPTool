using AutoMapper;

namespace CPTool.Implementations
{
    //public class GetById<TDTO, T> : IGetById<TDTO, T>
    //   where TDTO : IAuditableEntityDTO
    //   where T : IAuditableEntity

    //{
    //    readonly IUnitOfWork _unitofwork;
    //    readonly IMapper _mapper;

    //    public GetById(IUnitOfWork unitofwork, IMapper mapper)
    //    {
    //        _unitofwork = unitofwork;
    //        _mapper = mapper;
    //    }



        

    //    public async Task<IResult<TDTO>> Handle(int id)
    //    {
    //        var table = await _unitofwork.Repository<T>().GetByIdAsync(id);

    //        var dto = _mapper.Map<TDTO>(table);

    //        return dto==null? await Result<TDTO>.FailAsync( "Not found!"):await Result<TDTO>.SuccessAsync(dto, "row returned");
    //    }
    //}
}
