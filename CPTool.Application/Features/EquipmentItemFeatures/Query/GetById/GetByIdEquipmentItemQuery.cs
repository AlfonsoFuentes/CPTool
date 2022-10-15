using CPTool.Application.Features.EquipmentItemFeatures.CreateEdit;

namespace CPTool.Application.Features.EquipmentItemFeatures.Query.GetById
{
    
    //public class GetByIdEquipmentItemQuery : GetByIdQuery, IRequest<EditEquipmentItem>
    //{
    //}
    //public class GetByIdEquipmentItemQueryHandler : IRequestHandler<GetByIdEquipmentItemQuery, EditEquipmentItem>
    //{

    //    private readonly IMapper _mapper;
    //    private IUnitOfWork _unitofwork;
    //    public GetByIdEquipmentItemQueryHandler(IUnitOfWork unitofwork,
    //        IMapper mapper)
    //    {
    //        _unitofwork = unitofwork;
    //        _mapper = mapper;
    //    }
    //    public async Task<AddEditEquipmentItem> Handle(GetByIdEquipmentItemQuery request, CancellationToken cancellationToken)
    //    {
    //        var table = await _unitofwork.Repository<EquipmentItem>().GetByIdAsync(request.Id);

    //        return _mapper.Map<AddEditEquipmentItem>(table);

    //    }
    //}
    
}
