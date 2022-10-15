using CPTool.Application.Features.MWOItemFeatures.CreateEdit;

namespace CPTool.Application.Features.MWOItemFeatures.Query.GetList
{

    public class GetMWOItemListQuery : GetListQuery, IRequest<List<EditMWOItem>>
    {
       

       
    }
    public class GetMWOItemListQueryHandler : IRequestHandler<GetMWOItemListQuery, List<EditMWOItem>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetMWOItemListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<EditMWOItem>> Handle(GetMWOItemListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryMWOItem.GetAllAsync();

            return _mapper.Map<List<EditMWOItem>>(list);

        }
    }
}
