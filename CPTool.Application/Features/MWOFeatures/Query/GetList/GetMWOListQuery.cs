using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.Query.GetList;

namespace CPTool.Application.Features.MWOFeatures.Query.GetList
{

    public class GetMWOListQuery : GetListQuery, IRequest<List<EditMWO>>
    {



    }
    public class GetMWOListQueryHandler :
         GetListQueryHandler<EditMWO, MWO, GetMWOListQuery>, 
        IRequestHandler<GetMWOListQuery, List<EditMWO>>
    {
        public GetMWOListQueryHandler(IUnitOfWork unitofwork, IMapper mapper) : base(unitofwork, mapper)
        {
        }

        public override async Task<List<EditMWO>> Handle(GetMWOListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryMWO.GetAllAsync();

            return _mapper.Map<List<EditMWO>>(list);

        }
    }
}
