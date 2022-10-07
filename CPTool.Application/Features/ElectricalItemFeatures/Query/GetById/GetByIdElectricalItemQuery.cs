using CPTool.Application.Features.ElectricalItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.ElectricalItemFeatures.Query.GetById
{
    
    public class GetByIdElectricalItemQuery : GetByIdQuery, IRequest<AddEditElectricalItemCommand>
    {
    }
    public class GetByIdElectricalItemQueryHandler : IRequestHandler<GetByIdElectricalItemQuery, AddEditElectricalItemCommand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdElectricalItemQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddEditElectricalItemCommand> Handle(GetByIdElectricalItemQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<ElectricalItem>().GetByIdAsync(request.Id);

            return _mapper.Map<AddEditElectricalItemCommand>(table);

        }
    }
    
}
