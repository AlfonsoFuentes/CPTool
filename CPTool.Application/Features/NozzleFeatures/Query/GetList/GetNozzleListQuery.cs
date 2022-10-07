using CPTool.Application.Features.NozzleFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.NozzleFeatures.Query.GetList
{

    public class GetNozzleListQuery : GetListQuery, IRequest<List<AddEditNozzleCommand>>
    {
       

       
    }
    public class GetNozzleListQueryHandler : IRequestHandler<GetNozzleListQuery, List<AddEditNozzleCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetNozzleListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditNozzleCommand>> Handle(GetNozzleListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<Nozzle>().GetAllAsync();

            return _mapper.Map<List<AddEditNozzleCommand>>(list);

        }
    }
}
