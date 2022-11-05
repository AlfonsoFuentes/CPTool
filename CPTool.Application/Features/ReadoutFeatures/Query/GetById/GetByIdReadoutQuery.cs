using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderFeatures.Query.GetById;
using CPTool.Application.Features.ReadoutFeatures.CreateEdit;

namespace CPTool.Application.Features.ReadoutFeatures.Query.GetById
{

    public class GetByIdReadoutQuery : GetByIdQuery, IRequest<EditReadout>
    {
        public GetByIdReadoutQuery() { }
        
    }
    public class GetByIdReadoutQueryHandler : 
        GetByIdQueryHandler<EditReadout, Readout, GetByIdReadoutQuery>, 
        IRequestHandler<GetByIdReadoutQuery, EditReadout>
    {

       
        public GetByIdReadoutQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper) { }
    }
    
}
