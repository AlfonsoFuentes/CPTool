using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.Query.GetList;
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
                element!.nPipeClass!.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                element!.nGasket!.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                element!.nMaterial!.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                element!.StreamType.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                element!.ConnectionType!.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                ;
            return retorno;


        }
    }
    public class GetNozzleListQueryHandler : 
        GetListQueryHandler<EditNozzle, Nozzle, GetNozzleListQuery>,
        IRequestHandler<GetNozzleListQuery, List<EditNozzle>>
    {
        public GetNozzleListQueryHandler(IUnitOfWork unitofwork, IMapper mapper) : base(unitofwork, mapper)
        {
        }
    }
}
