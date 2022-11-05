using CPTool.Application.Features.BrandSupplierFeatures.CreateEdit;
using CPTool.Application.Features.MMOTypeFeatures.Query.GetById;

namespace CPTool.Application.Features.BrandSupplierFeatures.Query.GetById
{
    public class GetByIdBrandSupplierQuery : GetByIdQuery, IRequest<EditBrandSupplier>
    {
        public int BrandId { get; set; }
        public int SupplierId { get; set; }
        public GetByIdBrandSupplierQuery() { }

    }
    public class GetByIdBrandSupplierQueryHandler : GetByIdQueryHandler<EditBrandSupplier, BrandSupplier, GetByIdBrandSupplierQuery>,
        IRequestHandler<GetByIdBrandSupplierQuery, EditBrandSupplier>
    {


        public GetByIdBrandSupplierQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper) : base(unitofwork, mapper) { }

        public override async Task<EditBrandSupplier> Handle(GetByIdBrandSupplierQuery request, CancellationToken cancellationToken)
        {
            EditBrandSupplier retorno = new();
            if (request.BrandId != 0 && request.SupplierId != 0)
            {
                var table = await _unitofwork.RepositoryBrandSupplier.FirstOrDefaultAsync(x => x.BrandId == request.BrandId && x.SupplierId == request.SupplierId);
                retorno = _mapper.Map<EditBrandSupplier>(table);
            }

            return retorno;

        }
    }

}
