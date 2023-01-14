using AutoMapper;
using CPTool.ApplicationCQRS.Features.UserRequirements.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.UserRequirements.Queries.GetDetail
{
    public class GetUserRequirementDetailQueryHandler : IRequestHandler<GetUserRequirementDetailQuery, CommandUserRequirement>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetUserRequirementDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandUserRequirement> Handle(GetUserRequirementDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryUserRequirement.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandUserRequirement>(table);
            return dto;
        }
    }
}
