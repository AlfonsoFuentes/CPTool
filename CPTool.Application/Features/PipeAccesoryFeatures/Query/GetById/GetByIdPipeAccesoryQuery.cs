
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.Query.GetById;
using CPTool.Application.Features.MWOFeatures.Query.GetList;
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
        public override async Task<EditPipeAccesory> Handle(GetByIdPipeAccesoryQuery request, CancellationToken cancellationToken)
        {
            EditPipeAccesory result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositoryPipeAccesory.GetByIdAsync(request.Id);


                result = _mapper.Map<EditPipeAccesory>(table2);
            }




            return result;

        }
    }
   

}
