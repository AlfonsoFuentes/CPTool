using CPTool.Application.Features.FoundationItemFeatures.CreateEdit;

namespace CPTool.Application.Features.FoundationItemFeatures.Query.GetById
{
    
    //public class GetByIdFoundationItemQuery : GetByIdQuery, IRequest<AddFoundationItem>
    //{
    //}
    //public class GetByIdFoundationItemQueryHandler : IRequestHandler<GetByIdFoundationItemQuery, AddFoundationItem>
    //{

    //    private readonly IMapper _mapper;
    //    private IUnitOfWork _unitofwork;
    //    public GetByIdFoundationItemQueryHandler(IUnitOfWork unitofwork,
    //        IMapper mapper)
    //    {
    //        _unitofwork = unitofwork;
    //        _mapper = mapper;
    //    }
    //    public async Task<AddFoundationItem> Handle(GetByIdFoundationItemQuery request, CancellationToken cancellationToken)
    //    {
    //        var table = await _unitofwork.Repository<FoundationItem>().GetByIdAsync(request.Id);

    //        return _mapper.Map<AddFoundationItem>(table);

    //    }
    //}
    
}
