using CPTool.Application.Features.ElectricalItemFeatures.CreateEdit;

namespace CPTool.Application.Features.ElectricalItemFeatures.Query.GetById
{
    
    //public class GetByIdElectricalItemQuery : GetByIdQuery, IRequest<AddEditElectricalItem>
    //{
    //}
    //public class GetByIdElectricalItemQueryHandler : IRequestHandler<GetByIdElectricalItemQuery, AddEditElectricalItem>
    //{

    //    private readonly IMapper _mapper;
    //    private IUnitOfWork _unitofwork;
    //    public GetByIdElectricalItemQueryHandler(IUnitOfWork unitofwork,
    //        IMapper mapper)
    //    {
    //        _unitofwork = unitofwork;
    //        _mapper = mapper;
    //    }
    //    public async Task<AddEditElectricalItem> Handle(GetByIdElectricalItemQuery request, CancellationToken cancellationToken)
    //    {
    //        var table = await _unitofwork.Repository<ElectricalItem>().GetByIdAsync(request.Id);

    //        return _mapper.Map<AddEditElectricalItem>(table);

    //    }
    //}
    
}
