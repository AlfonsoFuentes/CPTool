using CPTool.Application.Features.MWOFeatures.CreateEdit;
namespace CPTool.Application.Features.MWOFeatures.Query.GetById
{

    public class GetByIdMWOQuery : GetByIdQuery, IRequest<EditMWO>
    {
        public GetByIdMWOQuery() { }

    }
    public class GetByIdMWOQueryHandler :
         GetByIdQueryHandler<EditMWO, MWO, GetByIdMWOQuery>,
        IRequestHandler<GetByIdMWOQuery, EditMWO>
    {


        public GetByIdMWOQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper) : base(unitofwork, mapper) { }
        public override async Task<EditMWO> Handle(GetByIdMWOQuery request, CancellationToken cancellationToken)
        {
            EditMWO result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositoryMWO.GetMWO_ItemsIdAsync(request.Id);


                result = _mapper.Map<EditMWO>(table2);
            }




            return result;

        }
    }

}
