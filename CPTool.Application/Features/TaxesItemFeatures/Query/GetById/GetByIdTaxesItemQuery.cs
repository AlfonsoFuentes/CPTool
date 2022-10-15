using CPTool.Application.Features.TaxesItemFeatures.CreateEdit;

namespace CPTool.Application.Features.TaxesItemFeatures.Query.GetById
{
    
    //public class GetByIdTaxesItemQuery : GetByIdQuery, IRequest<AddEditTaxesItem>
    //{
    //}
    //public class GetByIdTaxesItemQueryHandler : IRequestHandler<GetByIdTaxesItemQuery, AddEditTaxesItem>
    //{

    //    private readonly IMapper _mapper;
    //    private IUnitOfWork _unitofwork;
    //    public GetByIdTaxesItemQueryHandler(IUnitOfWork unitofwork,
    //        IMapper mapper)
    //    {
    //        _unitofwork = unitofwork;
    //        _mapper = mapper;
    //    }
    //    public async Task<AddEditTaxesItem> Handle(GetByIdTaxesItemQuery request, CancellationToken cancellationToken)
    //    {
    //        var table = await _unitofwork.Repository<TaxesItem>().GetByIdAsync(request.Id);

    //        return _mapper.Map<AddEditTaxesItem>(table);

    //    }
    //}
    
}
