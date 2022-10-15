
using CPTool.Application.Features.UnitFeatures.CreateEdit;

namespace CPTool.Application.Features.UnitFeatures.Query.GetList
{

    public class GetUnitListQuery : GetListQuery, IRequest<List<EditUnit>>
    {



    }
    public class GetUnitListQueryHandler : IRequestHandler<GetUnitListQuery, List<EditUnit>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetUnitListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<EditUnit>> Handle(GetUnitListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository< CPTool.Domain.Entities.Unit >().GetAllAsync();

            return _mapper.Map<List<EditUnit>>(list);

        }
    }
}
