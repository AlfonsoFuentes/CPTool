using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.MWOItemFeatures.Query.GetList
{

    public class GetMWOItemListQuery : GetListQuery, IRequest<List<AddEditMWOItemCommand>>
    {
       

       
    }
    public class GetMWOItemListQueryHandler : IRequestHandler<GetMWOItemListQuery, List<AddEditMWOItemCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetMWOItemListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditMWOItemCommand>> Handle(GetMWOItemListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<MWOItem>().GetAllAsync();

            return _mapper.Map<List<AddEditMWOItemCommand>>(list);

        }
    }
}
