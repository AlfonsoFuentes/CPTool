using CPTool.Application.Features.NozzleFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.NozzleFeatures.Query.GetById
{
    
    public class GetByIdNozzleQuery : GetByIdQuery, IRequest<AddEditNozzleCommand>
    {
    }
    public class GetByIdNozzleQueryHandler : IRequestHandler<GetByIdNozzleQuery, AddEditNozzleCommand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdNozzleQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddEditNozzleCommand> Handle(GetByIdNozzleQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<Nozzle>().GetByIdAsync(request.Id);

            return _mapper.Map<AddEditNozzleCommand>(table);

        }
    }
    
}
