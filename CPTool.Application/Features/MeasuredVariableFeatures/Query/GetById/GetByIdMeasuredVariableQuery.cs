using CPTool.Application.Features.MeasuredVariableFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.MeasuredVariableFeatures.Query.GetById
{
    
    public class GetByIdMeasuredVariableQuery : GetByIdQuery, IRequest<AddEditMeasuredVariableCommand>
    {
    }
    public class GetByIdMeasuredVariableQueryHandler : IRequestHandler<GetByIdMeasuredVariableQuery, AddEditMeasuredVariableCommand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdMeasuredVariableQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddEditMeasuredVariableCommand> Handle(GetByIdMeasuredVariableQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<MeasuredVariable>().GetByIdAsync(request.Id);

            return _mapper.Map<AddEditMeasuredVariableCommand>(table);

        }
    }
    
}
