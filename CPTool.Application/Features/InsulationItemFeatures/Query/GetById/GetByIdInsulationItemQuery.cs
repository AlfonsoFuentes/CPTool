using CPTool.Application.Features.InsulationItemFeatures.CreateEdit;

namespace CPTool.Application.Features.InsulationItemFeatures.Query.GetById
{
    
    //public class GetByIdInsulationItemQuery : GetByIdQuery, IRequest<AddEditInsulationItem>
    //{
    //}
    //public class GetByIdInsulationItemQueryHandler : IRequestHandler<GetByIdInsulationItemQuery, AddEditInsulationItem>
    //{

    //    private readonly IMapper _mapper;
    //    private IUnitOfWork _unitofwork;
    //    public GetByIdInsulationItemQueryHandler(IUnitOfWork unitofwork,
    //        IMapper mapper)
    //    {
    //        _unitofwork = unitofwork;
    //        _mapper = mapper;
    //    }
    //    public async Task<AddEditInsulationItem> Handle(GetByIdInsulationItemQuery request, CancellationToken cancellationToken)
    //    {
    //        var table = await _unitofwork.Repository<InsulationItem>().GetByIdAsync(request.Id);

    //        return _mapper.Map<AddEditInsulationItem>(table);

    //    }
    //}
    
}
