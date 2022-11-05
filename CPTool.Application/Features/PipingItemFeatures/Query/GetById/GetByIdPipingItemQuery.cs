using CPTool.Application.Features.PipeDiameterFeatures.CreateEdit;
using CPTool.Application.Features.PipeDiameterFeatures.Query.GetById;
using CPTool.Application.Features.PipingItemFeatures.CreateEdit;

namespace CPTool.Application.Features.PipingItemFeatures.Query.GetById
{

    public class GetByIdPipingItemQuery : GetByIdQuery, IRequest<EditPipingItem>
    {

    }
    public class GetByIdPipingItemQueryHandler :

         GetByIdQueryHandler<EditPipingItem, PipingItem, GetByIdPipingItemQuery>,
        IRequestHandler<GetByIdPipingItemQuery, EditPipingItem>
    {


        public GetByIdPipingItemQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper) : base(unitofwork, mapper)
        {

        }
        public override async Task<EditPipingItem> Handle(GetByIdPipingItemQuery request, CancellationToken cancellationToken)
        {
            EditPipingItem result = new();
            if (request.Id != 0)
            {
                var table = await _unitofwork.RepositoryPipingItem.GetByIdAsync(request.Id);

                result = _mapper.Map<EditPipingItem>(table);
            }


            return result;

        }
    }

}
