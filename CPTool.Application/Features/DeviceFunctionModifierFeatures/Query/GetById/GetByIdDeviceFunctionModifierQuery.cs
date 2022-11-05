using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.BrandFeatures.Query.GetById;
using CPTool.Application.Features.DeviceFunctionModifierFeatures.CreateEdit;

namespace CPTool.Application.Features.DeviceFunctionModifierFeatures.Query.GetById
{

    public class GetByIdDeviceFunctionModifierQuery : GetByIdQuery, IRequest<EditDeviceFunctionModifier>
    {
        public GetByIdDeviceFunctionModifierQuery() { }
        
    }
    public class GetByIdDeviceFunctionModifierQueryHandler : 
        GetByIdQueryHandler<EditDeviceFunctionModifier, DeviceFunctionModifier, GetByIdDeviceFunctionModifierQuery>,
        IRequestHandler<GetByIdDeviceFunctionModifierQuery, EditDeviceFunctionModifier>
    {

     
        public GetByIdDeviceFunctionModifierQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper) : base(unitofwork, mapper)
        {
           
        }
       
    }
    
}
