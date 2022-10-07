
using CPTool.Application.Features.StructuralItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.StructuralItemFeatures.Query.GetList
{

    public class GetStructuralItemListQuery : GetListQuery, IRequest<List<AddEditStructuralItemCommand>>
    {



    }
    public class GetStructuralItemListQueryHandler : IRequestHandler<GetStructuralItemListQuery, List<AddEditStructuralItemCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetStructuralItemListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditStructuralItemCommand>> Handle(GetStructuralItemListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<StructuralItem>().GetAllAsync();

            return _mapper.Map<List<AddEditStructuralItemCommand>>(list);

        }
    }
}
