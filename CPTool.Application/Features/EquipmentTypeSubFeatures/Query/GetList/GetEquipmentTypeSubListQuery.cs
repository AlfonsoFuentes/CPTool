namespace CPTool.Application.Features.EquipmentTypeSubFeatures.Query.GetList
{
    public class GetEquipmentTypeSubListQuery : GetListQuery, IRequest<List<EditEquipmentTypeSub>>
    {

        public int EquipmentTypeId { get; set; }
       
    }
    public class GetEquipmentTypeSubListQueryHandler : IRequestHandler<GetEquipmentTypeSubListQuery, List<EditEquipmentTypeSub>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetEquipmentTypeSubListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<EditEquipmentTypeSub>> Handle(GetEquipmentTypeSubListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<EquipmentTypeSub>().GetAsync(x => x.EquipmentTypeId == request.EquipmentTypeId);

            return _mapper.Map<List<EditEquipmentTypeSub>>(list);

        }
    }
}
