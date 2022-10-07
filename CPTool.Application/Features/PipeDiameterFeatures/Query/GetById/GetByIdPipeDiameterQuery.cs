using CPTool.Application.Features.PipeDiameterFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.PipeDiameterFeatures.Query.GetById
{
    
    public class GetByIdPipeDiameterQuery : GetByIdQuery, IRequest<AddEditPipeDiameterCommand>
    {
    }
    public class GetByIdPipeDiameterQueryHandler : IRequestHandler<GetByIdPipeDiameterQuery, AddEditPipeDiameterCommand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdPipeDiameterQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddEditPipeDiameterCommand> Handle(GetByIdPipeDiameterQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<PipeDiameter>().GetByIdAsync(request.Id);

            return _mapper.Map<AddEditPipeDiameterCommand>(table);

        }
    }
    
}
