using CPTool.Application.Features.UserRequirementFeatures.CreateEdit;
using CPTool.Application.Features.UserRequirementFeatures.Query.GetById;
using CPTool.Application.Features.UserRequirementTypeFeatures.CreateEdit;

namespace CPTool.Application.Features.UserRequirementTypeFeatures.Query.GetById
{

    public class GetByIdUserRequirementTypeQuery : GetByIdQuery, IRequest<EditUserRequirementType>
    {
        public GetByIdUserRequirementTypeQuery() { }
        
    }
    public class GetByIdUserRequirementTypeQueryHandler :
          GetByIdQueryHandler<EditUserRequirementType, UserRequirementType, GetByIdUserRequirementTypeQuery>, 
        IRequestHandler<GetByIdUserRequirementTypeQuery, EditUserRequirementType>
    {

      
        public GetByIdUserRequirementTypeQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper) { }    
    }
    
}
