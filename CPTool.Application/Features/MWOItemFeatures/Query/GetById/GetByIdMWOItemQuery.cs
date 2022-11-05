using CPTool.Application.Features.MeasuredVariableFeatures.CreateEdit;
using CPTool.Application.Features.MeasuredVariableFeatures.Query.GetById;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;

namespace CPTool.Application.Features.MWOItemFeatures.Query.GetById
{

    public class GetByIdMWOItemQuery : GetByIdQuery, IRequest<EditMWOItem>
    {
        public GetByIdMWOItemQuery() { }

    }
    public class GetByIdMWOItemQueryHandler :
         GetByIdQueryHandler<EditMWOItem, MWOItem, GetByIdMWOItemQuery>,
        IRequestHandler<GetByIdMWOItemQuery, EditMWOItem>
    {


        public GetByIdMWOItemQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper) : base(unitofwork, mapper) { }
        public override async Task<EditMWOItem> Handle(GetByIdMWOItemQuery request, CancellationToken cancellationToken)
        {
            EditMWOItem result = new();
            if (request.Id != 0)
            {
                var table = await _unitofwork.RepositoryMWOItem.GetMWOItemIdAsync(request.Id);

                result = _mapper.Map<EditMWOItem>(table);
            }



            return result;

        }
    }

}
