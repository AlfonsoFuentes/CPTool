using CPTool.Application.Features.EngineeringCostItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.EngineeringCostItemFeatures.Query.GetById
{
    
    public class GetByIdEngineeringCostItemQuery : GetByIdQuery, IRequest<AddEditEngineeringCostItemCommand>
    {
    }
    public class GetByIdEngineeringCostItemQueryHandler : IRequestHandler<GetByIdEngineeringCostItemQuery, AddEditEngineeringCostItemCommand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdEngineeringCostItemQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddEditEngineeringCostItemCommand> Handle(GetByIdEngineeringCostItemQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<EngineeringCostItem>().GetByIdAsync(request.Id);

            return _mapper.Map<AddEditEngineeringCostItemCommand>(table);

        }
    }
    
}
