using CPTool.Application.Features.UnitFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.UnitFeatures.Query.GetById
{
    
    public class GetByIdUnitQuery : GetByIdQuery, IRequest<AddEditUnitCommand>
    {
    }
    public class GetByIdUnitQueryHandler : IRequestHandler<GetByIdUnitQuery, AddEditUnitCommand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdUnitQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddEditUnitCommand> Handle(GetByIdUnitQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<CPTool.Domain.Entities.Unit>().GetByIdAsync(request.Id);

            return _mapper.Map<AddEditUnitCommand>(table);

        }
    }
    
}
