using CPTool.Application.Features.Base;
using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.EquipmentItemFeatures.CreateEdit;
using CPTool.Application.Features.EquipmentItemFeatures.Query.GetById;

namespace CPTool.Application.Features.BrandFeatures.Query.GetById
{
    public class GetByIdBrandQuery : GetByIdQuery, IRequest<EditBrand>
    {
        public GetByIdBrandQuery() { }

    }
    public class GetByIdBrandQueryHandler : GetByIdQueryHandler<EditBrand, Brand, GetByIdBrandQuery>,
        IRequestHandler<GetByIdBrandQuery, EditBrand>
    {


        public GetByIdBrandQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper) : base(unitofwork, mapper)
        {

        }
        public override async Task<EditBrand> Handle(GetByIdBrandQuery request, CancellationToken cancellationToken)
        {
            EditBrand result = new();
            if (request.Id != 0)
            {
                var table = await _unitofwork.RepositoryBrand.GetByIdAsync(request.Id);
                result = _mapper.Map<EditBrand>(table);
            }


            return result;

        }
    }

}
