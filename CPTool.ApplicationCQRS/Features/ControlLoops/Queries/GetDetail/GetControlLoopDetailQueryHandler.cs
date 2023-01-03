using AutoMapper;
using CPTool.ApplicationCQRS.Features.ControlLoops.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.ControlLoops.Queries.GetDetail
{
    public class GetControlLoopDetailQueryHandler : IRequestHandler<GetControlLoopDetailQuery, CommandControlLoop>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetControlLoopDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandControlLoop> Handle(GetControlLoopDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryControlLoop.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandControlLoop>(table);
            await AsignInternalItem(table.ControlledVariable!.MWOItem!);
            await AsignInternalItem(table.ProcessVariable!.MWOItem!);
            return dto;
        }
        async Task AsignInternalItem(MWOItem mWOItem)
        {
            switch (mWOItem.ChapterId)
            {
                case 1:
                    mWOItem.AlterationItem = await _UnitOfWork.RepositoryAlterationItem.GetByIdAsync(mWOItem!.AlterationItemId!.Value);
                    break;
                case 2:
                    mWOItem.FoundationItem = await _UnitOfWork.RepositoryFoundationItem.GetByIdAsync(mWOItem!.FoundationItemId!.Value);
                    break;
                case 3:
                    mWOItem.StructuralItem = await _UnitOfWork.RepositoryStructuralItem.GetByIdAsync(mWOItem!.StructuralItemId!.Value);
                    break;
                case 4:
                    mWOItem.EquipmentItem = await _UnitOfWork.RepositoryEquipmentItem.GetByIdAsync(mWOItem!.EquipmentItemId!.Value);

                    break;
                case 5:
                    mWOItem.ElectricalItem = await _UnitOfWork.RepositoryElectricalItem.GetByIdAsync(mWOItem!.ElectricalItemId!.Value);
                    break;
                case 6:
                    mWOItem.PipingItem = await _UnitOfWork.RepositoryPipingItem.GetByIdAsync(mWOItem!.PipingItemId!.Value);

                    break;
                case 7:
                    mWOItem.InstrumentItem = await _UnitOfWork.RepositoryInstrumentItem.GetByIdAsync(mWOItem!.InstrumentItemId!.Value);

                    break;
                case 8:
                    mWOItem.InsulationItem = await _UnitOfWork.RepositoryInsulationItem.GetByIdAsync(mWOItem!.InsulationItemId!.Value);
                    break;
                case 9:
                    mWOItem.PaintingItem = await _UnitOfWork.RepositoryPaintingItem.GetByIdAsync(mWOItem!.PaintingItemId!.Value);
                    break;
                case 10:
                    mWOItem.EHSItem = await _UnitOfWork.RepositoryEHSItem.GetByIdAsync(mWOItem!.EHSItemId!.Value);
                    break;
                case 11:
                    mWOItem.TaxesItem = await _UnitOfWork.RepositoryTaxesItem.GetByIdAsync(mWOItem!.TaxesItemId!.Value);
                    break;
                case 12:
                    mWOItem.TestingItem = await _UnitOfWork.RepositoryTestingItem.GetByIdAsync(mWOItem!.TestingItemId!.Value);
                    break;
                case 13:
                    mWOItem.EngineeringCostItem = await _UnitOfWork.RepositoryEngineeringCostItem.GetByIdAsync(mWOItem!.EngineeringCostItemId!.Value);
                    break;
                case 14:
                    mWOItem.ContingencyItem = await _UnitOfWork.RepositoryContingencyItem.GetByIdAsync(mWOItem!.ContingencyItemId!.Value);
                    break;

            }

        }
    }
}
