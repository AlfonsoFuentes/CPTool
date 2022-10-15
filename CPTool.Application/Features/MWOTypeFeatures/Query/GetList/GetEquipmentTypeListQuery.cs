namespace CPTool.Application.Features.MMOTypeFeatures.Query.GetList
{

    public class GetMWOTypeListQuery : GetListQuery, IRequest<List<EditMWOType>>
    {
       

       
    }
    public class GetMWOTypeListQueryHandler : IRequestHandler<GetMWOTypeListQuery, List<EditMWOType>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetMWOTypeListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<EditMWOType>> Handle(GetMWOTypeListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<MWOType>().GetAllAsync();

            return _mapper.Map<List<EditMWOType>>(list);

        }
    }
}
