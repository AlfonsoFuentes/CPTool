
using CPTool.Application.Features.NozzleFeatures.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.Query.GetList;
using CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit;

namespace CPTool.Application.Features.PipeAccesoryFeatures.Query.GetList
{

    public class GetPipeAccesoryListQuery : GetListQuery, IRequest<List<EditPipeAccesory>>
    {



    }
    public class GetPipeAccesoryListQueryHandler :
        GetListQueryHandler<EditPipeAccesory, PipeAccesory, GetPipeAccesoryListQuery>,
        IRequestHandler<GetPipeAccesoryListQuery, List<EditPipeAccesory>>
    {
        public GetPipeAccesoryListQueryHandler(IUnitOfWork unitofwork, IMapper mapper) : base(unitofwork, mapper)
        {
        }
    }
}
