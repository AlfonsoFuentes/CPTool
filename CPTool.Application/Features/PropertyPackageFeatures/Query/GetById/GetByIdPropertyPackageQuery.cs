using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;
using CPTool.Application.Features.ProcessFluidFeatures.Query.GetById;
using CPTool.Application.Features.PropertyPackageFeatures.CreateEdit;

namespace CPTool.Application.Features.PropertyPackageFeatures.Query.GetById
{

    public class GetByIdPropertyPackageQuery : GetByIdQuery, IRequest<EditPropertyPackage>
    {
        public GetByIdPropertyPackageQuery() { }

    }
    public class GetByIdProcessFluidQueryHandler :
        GetByIdQueryHandler<EditPropertyPackage, PropertyPackage, GetByIdPropertyPackageQuery>,
        IRequestHandler<GetByIdPropertyPackageQuery, EditPropertyPackage>
    {


        public GetByIdProcessFluidQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper) : base(unitofwork, mapper) { }
    }
}
