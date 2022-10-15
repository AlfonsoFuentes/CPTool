

namespace CPTool.Application.Features.EquipmentTypeFeatures.Query.GetList
{
   
    public class GetEquipmentTypeListQuery : GetListQuery, IRequest<List<EditEquipmentType>>
    {
        public GetEquipmentTypeListQuery()
        {
        }

      

    }
    public class GetEquipmentTypeListQueryHandler : IRequestHandler<GetEquipmentTypeListQuery, List<EditEquipmentType>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetEquipmentTypeListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<EditEquipmentType>> Handle(GetEquipmentTypeListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<EquipmentType>().GetAllAsync();

            return _mapper.Map<List<EditEquipmentType>>(list);

        }
    }
}
