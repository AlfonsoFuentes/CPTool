using AutoMapper;
using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;
using System.Diagnostics;

namespace CPTool.ApplicationCQRSFeatures.MWOItems.Queries.GetDetail
{
    public class GetMWOItemDetailQueryHandler : IRequestHandler<GetMWOItemDetailQuery, CommandMWOItem>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetMWOItemDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandMWOItem> Handle(GetMWOItemDetailQuery request, CancellationToken cancellationToken)
        {
            CommandMWOItem result = new();
            if (request.Id != 0)
            {
                
                var table = await _UnitOfWork.RepositoryMWOItem.GetByIdAsync(request.Id);
                if (table != null)
                {
                    await AsignInternalItem(table!);
                }
               
                result = _mapper.Map<CommandMWOItem>(table);
            }



            return result;
        }
        async Task AsignInternalItem(MWOItem mWOItem)
        {
            switch (mWOItem.ChapterId)
            {
                //case 1:
                //    mWOItem.AlterationItem = await _UnitOfWork.RepositoryAlterationItem.GetByIdAsync(mWOItem!.AlterationItemId!.Value);
                //    break;
                //case 2:
                //    mWOItem.FoundationItem = await _UnitOfWork.RepositoryFoundationItem.GetByIdAsync(mWOItem!.FoundationItemId!.Value);
                //    break;
                //case 3:
                //    mWOItem.StructuralItem = await _UnitOfWork.RepositoryStructuralItem.GetByIdAsync(mWOItem!.StructuralItemId!.Value);
                //    break;
                case 4:
                    //mWOItem.EquipmentItem = await _UnitOfWork.RepositoryEquipmentItem.GetByIdAsync(mWOItem!.EquipmentItemId!.Value);
                    //await AssignConnectedToMWOItem(mWOItem.EquipmentItem!.Nozzles!);
                    break;
                //case 5:
                //    mWOItem.ElectricalItem = await _UnitOfWork.RepositoryElectricalItem.GetByIdAsync(mWOItem!.ElectricalItemId!.Value);
                //    break;
                case 6:
                    //mWOItem.PipingItem = await _UnitOfWork.RepositoryPipingItem.GetByIdAsync(mWOItem!.PipingItemId!.Value);
                    //await AssignConnectedToMWOItem(mWOItem.PipingItem!.Nozzles!);
                    break;
                case 7:
                    //mWOItem.InstrumentItem = await _UnitOfWork.RepositoryInstrumentItem.GetByIdAsync(mWOItem!.InstrumentItemId!.Value);
                    //await AssignConnectedToMWOItem(mWOItem.InstrumentItem!.Nozzles!);
                    break;
                //case 8:
                //    mWOItem.InsulationItem = await _UnitOfWork.RepositoryInsulationItem.GetByIdAsync(mWOItem!.InsulationItemId!.Value);
                //    break;
                //case 9:
                //    mWOItem.PaintingItem = await _UnitOfWork.RepositoryPaintingItem.GetByIdAsync(mWOItem!.PaintingItemId!.Value);
                //    break;
                //case 10:
                //    mWOItem.EHSItem = await _UnitOfWork.RepositoryEHSItem.GetByIdAsync(mWOItem!.EHSItemId!.Value);
                //    break;
                //case 11:
                //    mWOItem.TaxesItem = await _UnitOfWork.RepositoryTaxesItem.GetByIdAsync(mWOItem!.TaxesItemId!.Value);
                //    break;
                //case 12:
                //    mWOItem.TestingItem = await _UnitOfWork.RepositoryTestingItem.GetByIdAsync(mWOItem!.TestingItemId!.Value);
                //    break;
                //case 13:
                //    mWOItem.EngineeringCostItem = await _UnitOfWork.RepositoryEngineeringCostItem.GetByIdAsync(mWOItem!.EngineeringCostItemId!.Value);
                //    break;
                //case 14:
                //    mWOItem.ContingencyItem = await _UnitOfWork.RepositoryContingencyItem.GetByIdAsync(mWOItem!.ContingencyItemId!.Value);
                //    break;

            }

        }

        //async Task AssignConnectedToMWOItem(ICollection<Nozzle> nozzles)
        //{
        //    foreach (var row in nozzles)
        //    {
        //        if (row.ConnectedTo != null)
        //        {
        //            row.ConnectedTo = await _UnitOfWork.RepositoryMWOItem.GetByIdFromListAsync(row.ConnectedTo.Id);
        //            switch (row.ConnectedTo!.Chapter!.Id)
        //            {
        //                case 4:
        //                    if (row.ConnectedTo!.EquipmentItemId != null)
        //                        row.ConnectedTo.EquipmentItem = await _UnitOfWork.RepositoryEquipmentItem.GetByIdFromListAsync(row.ConnectedTo!.EquipmentItemId!.Value);
        //                    break;
        //                case 6:
        //                    if (row.ConnectedTo!.PipingItemId != null)
        //                        row.ConnectedTo.PipingItem = await _UnitOfWork.RepositoryPipingItem.GetByIdFromListAsync(row.ConnectedTo!.PipingItemId!.Value);
        //                    break;
        //                case 7:
        //                    if (row.ConnectedTo!.InstrumentItemId != null)
        //                        row.ConnectedTo.InstrumentItem = await _UnitOfWork.RepositoryInstrumentItem.GetByIdFromListAsync(row.ConnectedTo!.InstrumentItemId!.Value);
        //                    break;
        //            }
        //        }
        //    }
        //}
    }
}
