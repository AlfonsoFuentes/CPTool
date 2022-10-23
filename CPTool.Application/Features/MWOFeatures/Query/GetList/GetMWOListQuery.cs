using CPTool.Application.Features.MWOFeatures.CreateEdit;

namespace CPTool.Application.Features.MWOFeatures.Query.GetList
{

    public class GetMWOListQuery : GetListQuery, IRequest<List<EditMWO>>
    {



    }
    public class GetMWOListQueryHandler : IRequestHandler<GetMWOListQuery, List<EditMWO>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetMWOListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<EditMWO>> Handle(GetMWOListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryMWO.GetAllAsync();

            return _mapper.Map<List<EditMWO>>(list);

        }
    }
}
