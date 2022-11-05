
using CPTool.Application.Features.UserRequirementTypeFeatures.CreateEdit;
using CPTool.Application.Features.UserRequirementTypeFeatures.Query.GetList;
using CPTool.Application.Features.WireFeatures.CreateEdit;

namespace CPTool.Application.Features.WireFeatures.Query.GetList
{

    public class GetWireListQuery : GetListQuery, IRequest<List<EditWire>>
    {



    }
    public class GetWireListQueryHandler :
         GetListQueryHandler<EditWire, Wire, GetWireListQuery>,
        IRequestHandler<GetWireListQuery, List<EditWire>>
    {
        public GetWireListQueryHandler(IUnitOfWork unitofwork, IMapper mapper) : base(unitofwork, mapper)
        {
        }
    }
}
