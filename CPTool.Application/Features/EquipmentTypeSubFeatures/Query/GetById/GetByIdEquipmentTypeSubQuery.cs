namespace CPTool.Application.Features.EquipmentTypeSubFeatures.Query.GetById
{
    public class GetByIdEquipmentTypeSubQuery : GetByIdQuery, IRequest<EditEquipmentTypeSub>
    {
        public GetByIdEquipmentTypeSubQuery() { }
        
    }
    public class GetByIdEquipmentTypeSubQueryHandler : IRequestHandler<GetByIdEquipmentTypeSubQuery, EditEquipmentTypeSub>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdEquipmentTypeSubQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<EditEquipmentTypeSub> Handle(GetByIdEquipmentTypeSubQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<EquipmentTypeSub>().GetByIdAsync(request.Id);

            return _mapper.Map<EditEquipmentTypeSub>(table);

        }
    }
    
}
