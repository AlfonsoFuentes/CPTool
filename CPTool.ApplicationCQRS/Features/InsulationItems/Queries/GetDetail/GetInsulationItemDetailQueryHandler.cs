using AutoMapper;
using CPTool.ApplicationCQRS.Features.InsulationItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.InsulationItems.Queries.GetDetail
{
    public class GetInsulationItemDetailQueryHandler : IRequestHandler<GetInsulationItemDetailQuery, CommandInsulationItem>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetInsulationItemDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandInsulationItem> Handle(GetInsulationItemDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryInsulationItem.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandInsulationItem>(table);
            return dto;
        }
    }
}
