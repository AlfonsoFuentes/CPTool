using AutoMapper;
using CPTool.ApplicationCQRS.Features.PurchaseOrders.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.PurchaseOrders.Queries.GetDetail
{
    public class GetPurchaseOrderDetailQueryHandler : IRequestHandler<GetPurchaseOrderDetailQuery, CommandPurchaseOrder>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetPurchaseOrderDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandPurchaseOrder> Handle(GetPurchaseOrderDetailQuery request, CancellationToken cancellationToken)
        {
            CommandPurchaseOrder dto = new();
            if(request.Id!=0)
            {
                var table = await _UnitOfWork.RepositoryPurchaseOrder.GetByIdAsync(request.Id);
                foreach (var row in table!.PurchaseOrderItems!)
                {
                    await AsignInternalItem(row.MWOItem!);
                }
                dto = _mapper.Map<CommandPurchaseOrder>(table);
            }
            
            return dto;
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
