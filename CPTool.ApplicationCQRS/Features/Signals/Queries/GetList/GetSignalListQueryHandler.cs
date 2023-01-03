using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.Signals.Queries.GetList;
using CPTool.ApplicationCQRS.Features.Signals.Commands.CreateUpdate;
using System.Linq.Expressions;

namespace CPTool.ApplicationCQRSFeatures.Signals.Queries.GetList
{
    public class GetSignalListQueryHandler : IRequestHandler<GetSignalsListQuery, List<CommandSignal>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetSignalListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandSignal>> Handle(GetSignalsListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Signal, bool>> predicate = request.MWOId == 0 ? x => x.MWOId != 0 : x => x.MWOId == request.MWOId;
            Func<IQueryable<Signal>, IOrderedQueryable<Signal>> orderBy = y => y.OrderBy(z => z.Name);
            var allSignal = (await _UnitOfWork.RepositorySignal.GetAllAsync(predicate));
            foreach(var row in allSignal)
            {
               await AsignInternalItem(row.MWOItem!);
            }
            return _mapper.Map<List<CommandSignal>>(allSignal);
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
