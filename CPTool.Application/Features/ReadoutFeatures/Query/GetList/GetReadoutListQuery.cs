
using CPTool.Application.Features.PurchaseOrderMWOItemFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderMWOItemFeatures.Query.GetList;
using CPTool.Application.Features.ReadoutFeatures.CreateEdit;

namespace CPTool.Application.Features.ReadoutFeatures.Query.GetList
{

    public class GetReadoutListQuery : GetListQuery, IRequest<List<EditReadout>>
    {



    }
    public class GetReadoutListQueryHandler :
         GetListQueryHandler<EditReadout, Readout, GetReadoutListQuery>,
        IRequestHandler<GetReadoutListQuery, List<EditReadout>>
    {
        public GetReadoutListQueryHandler(IUnitOfWork unitofwork, IMapper mapper) : base(unitofwork, mapper)
        {
        }
    }
}
