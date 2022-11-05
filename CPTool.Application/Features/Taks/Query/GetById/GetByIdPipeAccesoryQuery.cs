using CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit;
using CPTool.Application.Features.PipeAccesoryFeatures.Query.GetById;
using CPTool.Application.Features.TaksFeatures.CreateEdit;

namespace CPTool.Application.Features.TaksFeatures.Query.GetById
{

    public class GetByIdTaksQuery : GetByIdQuery, IRequest<EditTaks>
    {
        public GetByIdTaksQuery() { }

    }
    public class GetByIdPipeAccesoryQueryHandler :
         GetByIdQueryHandler<EditTaks, Taks, GetByIdTaksQuery>, 
        IRequestHandler<GetByIdTaksQuery, EditTaks>
    {

      
        public GetByIdPipeAccesoryQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper) { }
    }

}
