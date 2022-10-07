
using CPTool.Application.Features.UnitFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.UnitFeatures.Query.GetList
{

    public class GetUnitListQuery : GetListQuery, IRequest<List<AddEditUnitCommand>>
    {



    }
    public class GetUnitListQueryHandler : IRequestHandler<GetUnitListQuery, List<AddEditUnitCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetUnitListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditUnitCommand>> Handle(GetUnitListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository< CPTool.Domain.Entities.Unit >().GetAllAsync();

            return _mapper.Map<List<AddEditUnitCommand>>(list);

        }
    }
}
