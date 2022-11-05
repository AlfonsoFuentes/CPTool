
using AutoMapper;
using CPTool.Application.Features.PipeDiameterFeatures.CreateEdit;

namespace CPTool.Application.Features.PipeDiameterFeatures.Query.GetList
{

    public class GetPipeDiameterListQuery : GetListQuery, IRequest<List<EditPipeDiameter>>
    {



    }
    public class GetPipeDiameterListQueryHandler :
        GetListQueryHandler<EditPipeDiameter, PipeDiameter, GetPipeDiameterListQuery>,
        IRequestHandler<GetPipeDiameterListQuery, List<EditPipeDiameter>>
    {
        public GetPipeDiameterListQueryHandler(IUnitOfWork unitofwork, IMapper mapper) : base(unitofwork, mapper)
        {
        }
    }
}
