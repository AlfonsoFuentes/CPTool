namespace CPTool.Application.Features.EquipmentTypeFeatures.Query.GetById
{
    public class GetByIdEquipmentTypeQuery : GetByIdQuery, IRequest<AddEditEquipmentTypeCommand>
    {
    }
    public class GetByIdEquipmentTypeQueryHandler : IRequestHandler<GetByIdEquipmentTypeQuery, AddEditEquipmentTypeCommand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdEquipmentTypeQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddEditEquipmentTypeCommand> Handle(GetByIdEquipmentTypeQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<EquipmentType>().GetByIdAsync(request.Id);

            return _mapper.Map<AddEditEquipmentTypeCommand>(table);

        }
    }
    
}
