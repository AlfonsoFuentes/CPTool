
using CPTool.Application.Features.PropertyPackageFeatures.CreateEdit;

namespace CPTool.Application.Features.ProcessFluidFeatures.Query.GetList
{

    public class GetPropertyPackageListQuery : GetListQuery, IRequest<List<EditPropertyPackage>>
    {



    }
    public class GetPropertyPackageListQueryHandler :

         GetListQueryHandler<EditPropertyPackage, PropertyPackage, GetPropertyPackageListQuery>,
        IRequestHandler<GetPropertyPackageListQuery, List<EditPropertyPackage>>
    {
        public GetPropertyPackageListQueryHandler(IUnitOfWork unitofwork, IMapper mapper) : base(unitofwork, mapper)
        {
        }
    }
}
