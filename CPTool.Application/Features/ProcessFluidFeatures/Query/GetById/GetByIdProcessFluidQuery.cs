using CPTool.Application.Features.ProcessFluidFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.ProcessFluidFeatures.Query.GetById
{
    
    public class GetByIdProcessFluidQuery : GetByIdQuery, IRequest<AddEditProcessFluidCommand>
    {
    }
    public class GetByIdProcessFluidQueryHandler : IRequestHandler<GetByIdProcessFluidQuery, AddEditProcessFluidCommand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdProcessFluidQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddEditProcessFluidCommand> Handle(GetByIdProcessFluidQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<ProcessFluid>().GetByIdAsync(request.Id);

            return _mapper.Map<AddEditProcessFluidCommand>(table);

        }
    }
    
}
