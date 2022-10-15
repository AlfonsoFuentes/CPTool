using CPTool.Application.Features.PipeDiameterFeatures.CreateEdit;

namespace CPTool.Application.Features.PipeDiameterFeatures.Query.GetById
{

    public class GetByIdPipeDiameterQuery : GetByIdQuery, IRequest<EditPipeDiameter>
    {
        public GetByIdPipeDiameterQuery() { }
        
    }
    public class GetByIdPipeDiameterQueryHandler : IRequestHandler<GetByIdPipeDiameterQuery, EditPipeDiameter>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdPipeDiameterQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<EditPipeDiameter> Handle(GetByIdPipeDiameterQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<PipeDiameter>().GetByIdAsync(request.Id);

            return _mapper.Map<EditPipeDiameter>(table);

        }
    }
    
}
