
using CPTool.Application.Features.TaxesItemFeatures.CreateEdit;

namespace CPTool.Application.Features.TaxesItemFeatures.Query.GetList
{

    //public class GetTaxesItemListQuery : GetListQuery, IRequest<List<AddEditTaxesItem>>
    //{



    //}
    //public class GetTaxesItemListQueryHandler : IRequestHandler<GetTaxesItemListQuery, List<AddEditTaxesItem>>
    //{

    //    private readonly IMapper _mapper;
    //    private IUnitOfWork _unitofwork;
    //    public GetTaxesItemListQueryHandler(IUnitOfWork unitofwork,
    //        IMapper mapper)
    //    {
    //        _unitofwork = unitofwork;
    //        _mapper = mapper;
    //    }
    //    public async Task<List<AddEditTaxesItem>> Handle(GetTaxesItemListQuery request, CancellationToken cancellationToken)
    //    {
    //        var list = await _unitofwork.Repository<TaxesItem>().GetAllAsync();

    //        return _mapper.Map<List<AddEditTaxesItem>>(list);

    //    }
    //}
}
