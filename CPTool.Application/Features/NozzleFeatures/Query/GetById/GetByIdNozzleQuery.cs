using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.Query.GetById;
using CPTool.Application.Features.NozzleFeatures.CreateEdit;

namespace CPTool.Application.Features.NozzleFeatures.Query.GetById
{

    public class GetByIdNozzleQuery : GetByIdQuery, IRequest<EditNozzle>
    {
        public GetByIdNozzleQuery() { }
       
    }
    public class GetByIdNozzleQueryHandler : 
        GetByIdQueryHandler<EditNozzle, Nozzle, GetByIdNozzleQuery>,
        IRequestHandler<GetByIdNozzleQuery, EditNozzle>
    {

      
        public GetByIdNozzleQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper) { }
    }
    
}
