using CPTool.Application.Features.NozzleFeatures.CreateEdit;

namespace CPTool.Application.Features.NozzleFeatures.Query.GetById
{

    public class GetByIdNozzleQuery : GetByIdQuery, IRequest<EditNozzle>
    {
        public GetByIdNozzleQuery() { }
       
    }
    public class GetByIdNozzleQueryHandler : IRequestHandler<GetByIdNozzleQuery, EditNozzle>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdNozzleQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<EditNozzle> Handle(GetByIdNozzleQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<Nozzle>().GetByIdAsync(request.Id);

            return _mapper.Map<EditNozzle>(table);

        }
    }
    
}
