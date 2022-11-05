using CPTool.Application.Features.ProcessConditionFeatures.CreateEdit;
using CPTool.Application.Features.ProcessConditionFeatures.Query.GetById;
using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;

namespace CPTool.Application.Features.ProcessFluidFeatures.Query.GetById
{

    public class GetByIdProcessFluidQuery : GetByIdQuery, IRequest<EditProcessFluid>
    {
        public GetByIdProcessFluidQuery() { }
        
    }
    public class GetByIdProcessFluidQueryHandler :
        GetByIdQueryHandler<EditProcessFluid, ProcessFluid, GetByIdProcessFluidQuery>, 
        IRequestHandler<GetByIdProcessFluidQuery, EditProcessFluid>
    {

     
        public GetByIdProcessFluidQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper) { }
    }
    
}
