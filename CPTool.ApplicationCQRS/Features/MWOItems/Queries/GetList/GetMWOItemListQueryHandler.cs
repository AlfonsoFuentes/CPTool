using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.MWOItems.Queries.GetList;
using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.MWOItems.Queries.GetList
{
    public class GetMWOItemListQueryHandler : IRequestHandler<GetMWOItemsListQuery, List<CommandMWOItem>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetMWOItemListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandMWOItem>> Handle(GetMWOItemsListQuery request, CancellationToken cancellationToken)
        {
            var allMWOItem = (await _UnitOfWork.RepositoryMWOItem.GetAllAsync(x => x.MWOId == request.MWOId));


            foreach (var row in allMWOItem)
            {
                await AsignInternalItem(row);
            }
            return _mapper.Map<List<CommandMWOItem>>(allMWOItem);
        }
        async Task AsignInternalItem(MWOItem mWOItem)
        {
            switch (mWOItem.ChapterId)
            {
                case 1:
                    mWOItem.AlterationItem = await _UnitOfWork.RepositoryAlterationItem.GetByIdFromListAsync(mWOItem!.AlterationItemId!.Value);
                    break;
                case 2:
                    mWOItem.FoundationItem = await _UnitOfWork.RepositoryFoundationItem.GetByIdFromListAsync(mWOItem!.FoundationItemId!.Value);
                    break;
                case 3:
                    mWOItem.StructuralItem = await _UnitOfWork.RepositoryStructuralItem.GetByIdFromListAsync(mWOItem!.StructuralItemId!.Value);
                    break;
                case 4:
                    mWOItem.EquipmentItem = await _UnitOfWork.RepositoryEquipmentItem.GetByIdFromListAsync(mWOItem!.EquipmentItemId!.Value);
                    break;
                case 5:
                    mWOItem.ElectricalItem = await _UnitOfWork.RepositoryElectricalItem.GetByIdFromListAsync(mWOItem!.ElectricalItemId!.Value);
                    break;
                case 6:
                    mWOItem.PipingItem = await _UnitOfWork.RepositoryPipingItem.GetByIdFromListAsync(mWOItem!.PipingItemId!.Value);
                    break;
                case 7:
                    mWOItem.InstrumentItem = await _UnitOfWork.RepositoryInstrumentItem.GetByIdFromListAsync(mWOItem!.InstrumentItemId!.Value);
                    break;
                case 8:
                    mWOItem.InsulationItem = await _UnitOfWork.RepositoryInsulationItem.GetByIdFromListAsync(mWOItem!.InsulationItemId!.Value);
                    break;
                case 9:
                    mWOItem.PaintingItem = await _UnitOfWork.RepositoryPaintingItem.GetByIdFromListAsync(mWOItem!.PaintingItemId!.Value);
                    break;
                case 10:
                    mWOItem.EHSItem = await _UnitOfWork.RepositoryEHSItem.GetByIdFromListAsync(mWOItem!.EHSItemId!.Value);
                    break;
                case 11:
                    mWOItem.TaxesItem = await _UnitOfWork.RepositoryTaxesItem.GetByIdFromListAsync(mWOItem!.TaxesItemId!.Value);
                    break;
                case 12:
                    mWOItem.TestingItem = await _UnitOfWork.RepositoryTestingItem.GetByIdFromListAsync(mWOItem!.TestingItemId!.Value);
                    break;
                case 13:
                    mWOItem.EngineeringCostItem = await _UnitOfWork.RepositoryEngineeringCostItem.GetByIdFromListAsync(mWOItem!.EngineeringCostItemId!.Value);
                    break;
                case 14:
                    mWOItem.ContingencyItem = await _UnitOfWork.RepositoryContingencyItem.GetByIdFromListAsync(mWOItem!.ContingencyItemId!.Value);
                    break;

            }

        }
    }
    
}
