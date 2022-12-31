using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.EquipmentItems.Queries.GetList;
using CPTool.ApplicationCQRS.Features.EquipmentItems.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.EquipmentItems.Queries.GetList
{
    public class GetEquipmentItemListQueryHandler : IRequestHandler<GetEquipmentItemsListQuery, List<CommandEquipmentItem>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetEquipmentItemListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandEquipmentItem>> Handle(GetEquipmentItemsListQuery request, CancellationToken cancellationToken)
        {
            var allEquipmentItem = (await _UnitOfWork.RepositoryEquipmentItem.GetAllAsync());
            return _mapper.Map<List<CommandEquipmentItem>>(allEquipmentItem);
        }
    }
}
