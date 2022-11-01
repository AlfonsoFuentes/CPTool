using CPTool.Application.Features.Base;
using CPTool.Application.Features.EquipmentItemFeatures.CreateEdit;

namespace CPTool.Application.Features.EquipmentItemFeatures.Query.GetById
{

    public class GetByIdEquipmentItemQuery : GetByIdQuery, IRequest<EditEquipmentItem>
    {
    }
    public class GetByIdEquipmentItemQueryHandler : 
        IRequestHandler<GetByIdEquipmentItemQuery, EditEquipmentItem>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdEquipmentItemQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public  async Task<EditEquipmentItem> Handle(GetByIdEquipmentItemQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.RepositoryEquipmentItem.GetByIdAsync(request.Id);

            return _mapper.Map<EditEquipmentItem>(table);

        }
    }

}
