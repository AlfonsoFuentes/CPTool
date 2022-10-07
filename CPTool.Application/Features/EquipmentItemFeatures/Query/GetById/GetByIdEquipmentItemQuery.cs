using CPTool.Application.Features.EquipmentItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.EquipmentItemFeatures.Query.GetById
{
    
    public class GetByIdEquipmentItemQuery : GetByIdQuery, IRequest<AddEditEquipmentItemCommand>
    {
    }
    public class GetByIdEquipmentItemQueryHandler : IRequestHandler<GetByIdEquipmentItemQuery, AddEditEquipmentItemCommand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdEquipmentItemQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddEditEquipmentItemCommand> Handle(GetByIdEquipmentItemQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<EquipmentItem>().GetByIdAsync(request.Id);

            return _mapper.Map<AddEditEquipmentItemCommand>(table);

        }
    }
    
}
