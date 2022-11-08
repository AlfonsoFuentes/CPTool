
using CPTool.Application.Features.ControlLoopFeatures.CreateEdit;

namespace CPTool.Application.Features.ControlLoopFeatures.Query.GetById
{

    public class GetByIdControlLoopQuery : GetByIdQuery, IRequest<EditControlLoop>
    {
        public GetByIdControlLoopQuery() { }
       
    }
    public class GetByIdControlLoopQueryHandler : 
        GetByIdQueryHandler<EditControlLoop, ControlLoop, GetByIdControlLoopQuery>,
        IRequestHandler<GetByIdControlLoopQuery, EditControlLoop>
    {

      
        public GetByIdControlLoopQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper) { }
    }
    
}
