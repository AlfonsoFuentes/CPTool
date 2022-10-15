using CPTool.Application.Features.UnitFeatures.CreateEdit;

namespace CPTool.Application.Features.UnitFeatures.Query.GetById
{

    public class GetByIdUnitQuery : GetByIdQuery, IRequest<EditUnit>
    {
        public GetByIdUnitQuery() { }
        
    }
    public class GetByIdUnitQueryHandler : IRequestHandler<GetByIdUnitQuery, EditUnit>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdUnitQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<EditUnit> Handle(GetByIdUnitQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<CPTool.Domain.Entities.Unit>().GetByIdAsync(request.Id);

            return _mapper.Map<EditUnit>(table);

        }
    }
    
}
