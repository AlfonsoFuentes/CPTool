
using CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit;
using CPTool.Application.Features.PipeAccesoryFeatures.Query.GetList;
using CPTool.Application.Features.TaksFeatures.CreateEdit;

namespace CPTool.Application.Features.TaksFeatures.Query.GetList
{

    public class GetTaksListQuery : GetListQuery, IRequest<List<EditTaks>>
    {



    }
    public class GetTaksListQueryHandler :
        GetListQueryHandler<EditTaks, Taks, GetTaksListQuery>, 
        IRequestHandler<GetTaksListQuery, List<EditTaks>>
    {
        public GetTaksListQueryHandler(IUnitOfWork unitofwork, IMapper mapper) : base(unitofwork, mapper)
        {
        }

        public override async Task<List<EditTaks>> Handle(GetTaksListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<Taks>().GetAllAsync();
            list = list.Where(x => x.TaksStatus==TaksStatus.Pending).OrderBy(x=>x.CreatedDate).ToList();
            return _mapper.Map<List<EditTaks>>(list);

        }
    }
}
