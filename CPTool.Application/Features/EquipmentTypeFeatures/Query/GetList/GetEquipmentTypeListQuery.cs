

namespace CPTool.Application.Features.EquipmentTypeFeatures.Query.GetList
{
   
    public class GetEquipmentTypeListQuery : GetListQuery, IRequest<List<AddEditEquipmentTypeCommand>>
    {
        public GetEquipmentTypeListQuery()
        {
        }

      

    }
    public class GetEquipmentTypeListQueryHandler : IRequestHandler<GetEquipmentTypeListQuery, List<AddEditEquipmentTypeCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetEquipmentTypeListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditEquipmentTypeCommand>> Handle(GetEquipmentTypeListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<EquipmentType>().GetAsync(null!,null!,true,true);

            return _mapper.Map<List<AddEditEquipmentTypeCommand>>(list);

        }
    }
}
