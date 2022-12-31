using AutoMapper;
using CPTool.ApplicationCQRS.Features.PipeDiameters.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.PipeDiameters.Queries.GetDetail
{
    public class GetPipeDiameterDetailQueryHandler : IRequestHandler<GetPipeDiameterDetailQuery, CommandPipeDiameter>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetPipeDiameterDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandPipeDiameter> Handle(GetPipeDiameterDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryPipeDiameter.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandPipeDiameter>(table);
            return dto;
        }
    }
}
