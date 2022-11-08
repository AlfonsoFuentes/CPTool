using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.Query.GetList;
using CPTool.Application.Features.ControlLoopFeatures.CreateEdit;

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
    }
}
