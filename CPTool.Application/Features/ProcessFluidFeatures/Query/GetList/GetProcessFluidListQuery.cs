
using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;

namespace CPTool.Application.Features.ProcessFluidFeatures.Query.GetList
{

    public class GetProcessFluidListQuery : GetListQuery, IRequest<List<EditProcessFluid>>
    {



    }
    public class GetProcessFluidListQueryHandler :
          GetListQueryHandler<EditProcessFluid, ProcessFluid, GetProcessFluidListQuery>,
        IRequestHandler<GetProcessFluidListQuery, List<EditProcessFluid>>
    {
        public GetProcessFluidListQueryHandler(IUnitOfWork unitofwork, IMapper mapper) : base(unitofwork, mapper)
        {
        }
    }
}
