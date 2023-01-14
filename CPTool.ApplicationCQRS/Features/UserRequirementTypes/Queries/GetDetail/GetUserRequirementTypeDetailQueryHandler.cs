using AutoMapper;
using CPTool.ApplicationCQRS.Features.UserRequirementTypes.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.UserRequirementTypes.Queries.GetDetail
{
    public class GetUserRequirementTypeDetailQueryHandler : IRequestHandler<GetUserRequirementTypeDetailQuery, CommandUserRequirementType>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetUserRequirementTypeDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandUserRequirementType> Handle(GetUserRequirementTypeDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryUserRequirementType.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandUserRequirementType>(table);
            return dto;
        }
    }
}
