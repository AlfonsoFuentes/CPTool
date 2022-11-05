using CPTool.Application.Features.UnitFeatures.CreateEdit;
using CPTool.Application.Features.UnitFeatures.Query.GetById;
using CPTool.Application.Features.UserRequirementFeatures.CreateEdit;

namespace CPTool.Application.Features.UserRequirementFeatures.Query.GetById
{

    public class GetByIdUserRequirementQuery : GetByIdQuery, IRequest<EditUserRequirement>
    {
        public GetByIdUserRequirementQuery() { }
        
    }
    public class GetByIdUserRequirementQueryHandler :
        GetByIdQueryHandler<EditUserRequirement, UserRequirement, GetByIdUserRequirementQuery>, 
        IRequestHandler<GetByIdUserRequirementQuery, EditUserRequirement>
    {

       
        public GetByIdUserRequirementQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper) { }
    }
    
}
