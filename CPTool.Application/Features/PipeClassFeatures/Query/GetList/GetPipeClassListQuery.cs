
using CPTool.Application.Features.PipeClassFeatures.CreateEdit;
using CPTool.Application.Features.TaksFeatures.CreateEdit;
using CPTool.Application.Features.TaksFeatures.Query.GetList;

namespace CPTool.Application.Features.PipeClassFeatures.Query.GetList
{

    public class GetPipeClassListQuery : GetListQuery, IRequest<List<EditPipeClass>>
    {



    }
    public class GetPipeClassListQueryHandler :
        GetListQueryHandler<EditPipeClass, PipeClass, GetPipeClassListQuery>,
        IRequestHandler<GetPipeClassListQuery, List<EditPipeClass>>
    {
        public GetPipeClassListQueryHandler(IUnitOfWork unitofwork, IMapper mapper) : base(unitofwork, mapper)
        {
        }
    }
}
