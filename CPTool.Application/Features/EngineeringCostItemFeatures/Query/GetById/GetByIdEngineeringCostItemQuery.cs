using CPTool.Application.Features.EngineeringCostItemFeatures.CreateEdit;

namespace CPTool.Application.Features.EngineeringCostItemFeatures.Query.GetById
{
    
    //public class GetByIdEngineeringCostItemQuery : GetByIdQuery, IRequest<AddEditEngineeringCostItem>
    //{
    //}
    //public class GetByIdEngineeringCostItemQueryHandler : IRequestHandler<GetByIdEngineeringCostItemQuery, AddEditEngineeringCostItem>
    //{

    //    private readonly IMapper _mapper;
    //    private IUnitOfWork _unitofwork;
    //    public GetByIdEngineeringCostItemQueryHandler(IUnitOfWork unitofwork,
    //        IMapper mapper)
    //    {
    //        _unitofwork = unitofwork;
    //        _mapper = mapper;
    //    }
    //    public async Task<AddEditEngineeringCostItem> Handle(GetByIdEngineeringCostItemQuery request, CancellationToken cancellationToken)
    //    {
    //        var table = await _unitofwork.Repository<EngineeringCostItem>().GetByIdAsync(request.Id);

    //        return _mapper.Map<AddEditEngineeringCostItem>(table);

    //    }
    //}
    
}
