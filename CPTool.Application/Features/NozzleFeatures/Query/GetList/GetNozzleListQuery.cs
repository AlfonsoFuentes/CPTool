using CPTool.Application.Features.NozzleFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.NozzleFeatures.Query.GetList
{

    public class GetNozzleListQuery : GetListQuery, IRequest<List<AddEditNozzleCommand>>
    {


        public override bool FilterFunc(AddEditCommand element1, string searchString)
        {
            var element = element1 as AddEditNozzleCommand;

            var retorno = element!.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)||
                element!.PipeDiameterCommand!.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                element!.PipeClassCommand!.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                element!.GasketCommand!.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                element!.MaterialCommand!.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                element!.StreamType.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                element!.ConnectionTypeCommand!.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                ;
            return retorno;


        }
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
