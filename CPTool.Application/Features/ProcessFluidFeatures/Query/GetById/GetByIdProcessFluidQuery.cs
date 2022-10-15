using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;

namespace CPTool.Application.Features.ProcessFluidFeatures.Query.GetById
{

    public class GetByIdProcessFluidQuery : GetByIdQuery, IRequest<EditProcessFluid>
    {
        public GetByIdProcessFluidQuery() { }
        
    }
    public class GetByIdProcessFluidQueryHandler : IRequestHandler<GetByIdProcessFluidQuery, EditProcessFluid>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdProcessFluidQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<EditProcessFluid> Handle(GetByIdProcessFluidQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<ProcessFluid>().GetByIdAsync(request.Id);

            return _mapper.Map<EditProcessFluid>(table);

        }
    }
    
}
