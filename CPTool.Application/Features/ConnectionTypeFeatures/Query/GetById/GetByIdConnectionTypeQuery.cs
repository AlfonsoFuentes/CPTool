using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.BrandFeatures.Query.GetById;
using CPTool.Application.Features.ConnectionTypeFeatures.CreateEdit;

namespace CPTool.Application.Features.ConnectionTypeFeatures.Query.GetById
{

    public class GetByIdConnectionTypeQuery : GetByIdQuery, IRequest<EditConnectionType>
    {
        public GetByIdConnectionTypeQuery() { }

    }
    public class GetByIdConnectionTypeQueryHandler : GetByIdQueryHandler<EditConnectionType, ConnectionType, GetByIdConnectionTypeQuery>,
        IRequestHandler<GetByIdConnectionTypeQuery, EditConnectionType>
    {


        public GetByIdConnectionTypeQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper) : base(unitofwork, mapper)
        {

        }

    }

}
