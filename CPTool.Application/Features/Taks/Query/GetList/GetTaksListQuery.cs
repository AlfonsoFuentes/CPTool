
using CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit;
using CPTool.Application.Features.PipeAccesoryFeatures.Query.GetList;
using CPTool.Application.Features.TaksFeatures.CreateEdit;

namespace CPTool.Application.Features.TaksFeatures.Query.GetList
{

    public class GetTaksListQuery : GetListQuery, IRequest<List<EditTaks>>
    {

        public override bool FilterFunc(EditCommand element1, string searchString)
        {
            var element = element1 as EditTaks;
            var retorno = element!.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                element!.MWO!.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                element!.MWO!.CECName.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                element!.TaksType.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                element!.TaksStatus.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase) 

          ;

            return retorno;


        }

    }
    public class GetTaksListQueryHandler :
        GetListQueryHandler<EditTaks, Taks, GetTaksListQuery>,
        IRequestHandler<GetTaksListQuery, List<EditTaks>>
    {
        public GetTaksListQueryHandler(IUnitOfWork unitofwork, IMapper mapper) : base(unitofwork, mapper)
        {
        }

        public override async Task<List<EditTaks>> Handle(GetTaksListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<Taks>().GetAllAsync();
            list = list.OrderBy(x=>x.TaksType).ThenBy(x=>x.TaksStatus).ThenBy(x => x.CreatedDate).ToList();
            return _mapper.Map<List<EditTaks>>(list);

        }
    }
}
