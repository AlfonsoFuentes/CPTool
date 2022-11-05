
using CPTool.Application.Features.DeviceFunctionModifierFeatures.CreateEdit;

namespace CPTool.Application.Features.DeviceFunctionModifierFeatures.Query.GetList
{

    public class GetDeviceFunctionModifierListQuery : GetListQuery, IRequest<List<EditDeviceFunctionModifier>>
    {



    }
    public class GetUnitaryBasePrizeListQueryHandler :
           GetListQueryHandler<EditDeviceFunctionModifier, DeviceFunctionModifier, GetDeviceFunctionModifierListQuery>, 
        IRequestHandler<GetDeviceFunctionModifierListQuery, List<EditDeviceFunctionModifier>>
    {


        public GetUnitaryBasePrizeListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper) : base(unitofwork, mapper) { }
    }
}
