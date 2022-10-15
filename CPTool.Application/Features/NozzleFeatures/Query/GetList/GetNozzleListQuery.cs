using CPTool.Application.Features.NozzleFeatures.CreateEdit;

namespace CPTool.Application.Features.NozzleFeatures.Query.GetList
{

    public class GetNozzleListQuery : GetListQuery, IRequest<List<EditNozzle>>
    {


        public override bool FilterFunc(EditCommand element1, string searchString)
        {
            var element = element1 as EditNozzle;

            var retorno = element!.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)||
                element!.PipeDiameter!.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                element!.PipeClass!.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                element!.Gasket!.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                element!.Material!.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                element!.StreamType.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                element!.ConnectionType!.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                ;
            return retorno;


        }
    }
    public class GetNozzleListQueryHandler : IRequestHandler<GetNozzleListQuery, List<EditNozzle>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetNozzleListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<EditNozzle>> Handle(GetNozzleListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<Nozzle>().GetAllAsync();

            return _mapper.Map<List<EditNozzle>>(list);

        }
    }
}
