using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.InsulationItems.Queries.GetList;
using CPTool.ApplicationCQRS.Features.InsulationItems.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.InsulationItems.Queries.GetList
{
    public class GetInsulationItemListQueryHandler : IRequestHandler<GetInsulationItemsListQuery, List<CommandInsulationItem>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetInsulationItemListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandInsulationItem>> Handle(GetInsulationItemsListQuery request, CancellationToken cancellationToken)
        {
            var allInsulationItem = (await _UnitOfWork.RepositoryInsulationItem.GetAllAsync());
            return _mapper.Map<List<CommandInsulationItem>>(allInsulationItem);
        }
    }
}
