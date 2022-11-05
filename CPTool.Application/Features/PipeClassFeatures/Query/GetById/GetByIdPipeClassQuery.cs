using CPTool.Application.Features.PipeClassFeatures.CreateEdit;
using CPTool.Application.Features.TaksFeatures.CreateEdit;
using CPTool.Application.Features.TaksFeatures.Query.GetById;

namespace CPTool.Application.Features.PipeClassFeatures.Query.GetById
{

    public class GetByIdPipeClassQuery : GetByIdQuery, IRequest<EditPipeClass>
    {
        public GetByIdPipeClassQuery() { }
       
    }
    public class GetByIdPipeClassQueryHandler : GetByIdQueryHandler<EditPipeClass, PipeClass, GetByIdPipeClassQuery>, 
        IRequestHandler<GetByIdPipeClassQuery, EditPipeClass>
    {

      
        public GetByIdPipeClassQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper) { }
    }
    
}
