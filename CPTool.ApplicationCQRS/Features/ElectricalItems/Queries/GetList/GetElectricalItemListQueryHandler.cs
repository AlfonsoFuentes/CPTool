using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.ElectricalItems.Queries.GetList;
using CPTool.ApplicationCQRS.Features.ElectricalItems.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.ElectricalItems.Queries.GetList
{
    public class GetElectricalItemListQueryHandler : IRequestHandler<GetElectricalItemsListQuery, List<CommandElectricalItem>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetElectricalItemListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandElectricalItem>> Handle(GetElectricalItemsListQuery request, CancellationToken cancellationToken)
        {
            var allElectricalItem = (await _UnitOfWork.RepositoryElectricalItem.GetAllAsync());
            return _mapper.Map<List<CommandElectricalItem>>(allElectricalItem);
        }
    }
}
