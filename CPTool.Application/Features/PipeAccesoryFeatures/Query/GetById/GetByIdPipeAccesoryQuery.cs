using CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit;

namespace CPTool.Application.Features.PipeAccesoryFeatures.Query.GetById
{

    public class GetByIdPipeAccesoryQuery : GetByIdQuery, IRequest<EditPipeAccesory>
    {
        public GetByIdPipeAccesoryQuery() { }
       
    }
    public class GetByIdPipeAccesoryQueryHandler :
         GetByIdQueryHandler<EditPipeAccesory, PipeAccesory, GetByIdPipeAccesoryQuery>, 
        IRequestHandler<GetByIdPipeAccesoryQuery, EditPipeAccesory>
    {

      
        public GetByIdPipeAccesoryQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper) { }
    }
    
}
