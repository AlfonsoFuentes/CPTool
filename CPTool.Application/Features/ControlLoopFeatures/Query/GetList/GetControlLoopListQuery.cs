using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.Query.GetList;
using CPTool.Application.Features.ControlLoopFeatures.CreateEdit;
using static System.Net.Mime.MediaTypeNames;

namespace CPTool.Application.Features.ControlLoopFeatures.Query.GetList
{

    public class GetControlLoopListQuery : GetListQuery, IRequest<List<EditControlLoop>>
    {


       
    }
    public class GetControlLoopListQueryHandler : 
        GetListQueryHandler<EditControlLoop, ControlLoop, GetControlLoopListQuery>,
        IRequestHandler<GetControlLoopListQuery, List<EditControlLoop>>
    {
        public GetControlLoopListQueryHandler(IUnitOfWork unitofwork, IMapper mapper) : base(unitofwork, mapper)
        {
        }
        public override async Task<List<EditControlLoop>> Handle(GetControlLoopListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<ControlLoop>().GetAllAsync();
            list= list.OrderBy(x=>x.ControlLoopType).ToList();
            return _mapper.Map<List<EditControlLoop>>(list);

        }
    }
}
