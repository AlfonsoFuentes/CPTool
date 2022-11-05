using CPTool.Application.Features.UserRequirementTypeFeatures.CreateEdit;
using CPTool.Application.Features.UserRequirementTypeFeatures.Query.GetById;
using CPTool.Application.Features.WireFeatures.CreateEdit;

namespace CPTool.Application.Features.WireFeatures.Query.GetById
{

    public class GetByIdWireQuery : GetByIdQuery, IRequest<EditWire>
    {
        public GetByIdWireQuery() { }
        
    }
    public class GetByIdWireQueryHandler :
         GetByIdQueryHandler<EditWire, Wire, GetByIdWireQuery>, 
        IRequestHandler<GetByIdWireQuery, EditWire>
    {

       
        public GetByIdWireQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper) { }
    }
    
}
