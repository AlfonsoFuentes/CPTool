using CPTool.Application.Features.FieldLocationFeatures.Query.GetById;
using CPTool.Application.Features.FieldLocationsFeatures.CreateEdit;
using CPTool.Application.Features.GasketsFeatures.CreateEdit;

namespace CPTool.Application.Features.GasketFeatures.Query.GetById
{

    public class GetByIdGasketQuery : GetByIdQuery, IRequest<EditGasket>
    {
        public GetByIdGasketQuery() { }
       
    }
    public class GetByIdGasketQueryHandler : GetByIdQueryHandler<EditGasket, Gasket, GetByIdGasketQuery>, 
        
        IRequestHandler<GetByIdGasketQuery, EditGasket>
    {

       
        public GetByIdGasketQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper) { }
    }

}
