using CPTool.Application.Features.ReadoutFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.ReadoutFeatures.Query.GetById
{
    
    public class GetByIdReadoutQuery : GetByIdQuery, IRequest<AddEditReadoutCommand>
    {
    }
    public class GetByIdReadoutQueryHandler : IRequestHandler<GetByIdReadoutQuery, AddEditReadoutCommand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdReadoutQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddEditReadoutCommand> Handle(GetByIdReadoutQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<Readout>().GetByIdAsync(request.Id);

            return _mapper.Map<AddEditReadoutCommand>(table);

        }
    }
    
}
