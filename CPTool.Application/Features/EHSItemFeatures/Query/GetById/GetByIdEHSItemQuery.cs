using CPTool.Application.Features.EHSItemFeatures.CreateEdit;

namespace CPTool.Application.Features.EHSItemFeatures.Query.GetById
{
    
    //public class GetByIdEHSItemQuery : GetByIdQuery, IRequest<AddEditEHSItem>
    //{
    //}
    //public class GetByIdEHSItemQueryHandler : IRequestHandler<GetByIdEHSItemQuery, AddEditEHSItem>
    //{

    //    private readonly IMapper _mapper;
    //    private IUnitOfWork _unitofwork;
    //    public GetByIdEHSItemQueryHandler(IUnitOfWork unitofwork,
    //        IMapper mapper)
    //    {
    //        _unitofwork = unitofwork;
    //        _mapper = mapper;
    //    }
    //    public async Task<AddEditEHSItem> Handle(GetByIdEHSItemQuery request, CancellationToken cancellationToken)
    //    {
    //        var table = await _unitofwork.Repository<EHSItem>().GetByIdAsync(request.Id);

    //        return _mapper.Map<AddEditEHSItem>(table);

    //    }
    //}
    
}
