using CPTool.Domain.Common;
using CPTool.ApplicationCQRS.Contracts.Persistence;


using CPToolCQRS.Infrastructure.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using CPTool.PersistenceCQRS.Extensions;
using CPTool.Persistence.Persistence;

namespace CPTool.PersistenceCQRS.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        IRepositoryBrand _RepositoryBrand = null!;
        IRepositoryBrandSupplier _RepositoryBrandSupplier = null!;

        IRepositoryChapter _RepositoryChapter = null!;
        IRepositoryConnectionType _RepositoryConnectionType = null!;
        IRepositoryControlLoop _RepositoryControlLoop = null!;
        IRepositoryDeviceFunction _RepositoryDeviceFunction = null!;
        IRepositoryDeviceFunctionModifier _RepositoryDeviceFunctionModifier = null!;
        IRepositoryDownPayment _RepositoryDownPayment = null!;
        IRepositoryElectricalBox _RepositoryElectricalBox = null!;
        IRepositoryEntityUnit _RepositoryEntityUnit = null!;
        IRepositoryEquipmentType _RepositoryEquipmentType = null!;
        IRepositoryGasket _RepositoryGasket = null!;
        IRepositoryEquipmentTypeSub _RepositoryEquipmentTypeSub = null!;
        IRepositoryFieldLocation _RepositoryFieldLocation = null!;
        IRepositoryMaterial _RepositoryMaterial = null!;
        IRepositoryMeasuredVariable _RepositoryMeasuredVariable = null!;
        IRepositoryMeasuredVariableModifier _RepositoryMeasuredVariableModifier = null!;
        IRepositoryMWO _RepositoryMWO = null!;
        IRepositoryMWOType _RepositoryMWOType = null!;
        IRepositoryMWOItem _RepositoryMWOItem = null!;
        IRepositoryMWOItemWithEquipment _RepositoryMWOItemWithEquipment = null!;
        IRepositoryMWOItemWithInstrument _RepositoryMWOItemWithInstrument = null!;
        IRepositoryMWOItemWithPiping _RepositoryMWOItemWithPiping = null!;
        IRepositoryMWOItemWithNozzles _RepositoryMWOItemWithNozzles = null!;
        IRepositoryNozzle _RepositoryNozzle = null!;
        IRepositoryPipeAccesory _RepositoryPipeAccesory = null!;
        IRepositoryPipeClass _RepositoryPipeClass = null!;
        IRepositoryPipeDiameter _RepositoryPipeDiameter = null!;
        IRepositoryProcessCondition _RepositoryProcessCondition = null!;
        IRepositoryProcessFluid _RepositoryProcessFluid = null!;
        IRepositoryPropertyPackage _RepositoryPropertyPackage = null!;

        IRepositoryPurchaseOrder _RepositoryPurchaseOrder = null!;
        IRepositoryPurchaseOrderItem _RepositoryPurchaseOrderItem = null!;
        IRepositoryReadout _RepositoryReadout = null!;
        IRepositorySignal _RepositorySignal = null!;
        IRepositorySignalModifier _RepositorySignalModifier = null!;
        IRepositorySignalType _RepositorySignalType = null!;
        IRepositorySupplier _RepositorySupplier = null!;
        IRepositoryTaks _RepositoryTaks = null!;
        IRepositoryTaxCodeLD _RepositoryTaxCodeLD = null!;
        IRepositoryTaxCodeLP _RepositoryTaxCodeLP = null!;
        IRepositoryUnitaryBasePrize _RepositoryUnitaryBasePrize = null!;
        IRepositoryUser _RepositoryUser = null!;
        IRepositoryUserRequirement _RepositoryUserRequirement = null!;
        IRepositoryUserRequirementType _RepositoryUserRequirementType = null!;
        IRepositoryWire _RepositoryWire = null!;
        IRepositoryAlterationItem _RepositoryAlterationItem = null!;
        IRepositoryFoundationItem _RepositoryFoundationItem = null!;
        IRepositoryStructuralItem _RepositoryStructuralItem = null!;
        IRepositoryEquipmentItem _RepositoryEquipmentItem = null!;
  
        IRepositoryElectricalItem _RepositoryElectricalItem = null!;
        IRepositoryInstrumentItem _RepositoryInstrumentItem = null!;
      
        IRepositoryInsulationItem _RepositoryInsulationItem = null!;
        IRepositoryPipingItem _RepositoryPipingItem = null!;
    
        IRepositoryPaintingItem _RepositoryPaintingItem = null!;
        IRepositoryEHSItem _RepositoryEHSItem = null!;
        IRepositoryTaxesItem _RepositoryTaxesItem = null!;
        IRepositoryTestingItem _RepositoryTestingItem = null!;
        IRepositoryEngineeringCostItem _RepositoryEngineeringCostItem = null!;
        IRepositoryContingencyItem _RepositoryContingencyItem = null!;


   
        private readonly TableContext _context;





        protected readonly IMediator _mediator;
        public UnitOfWork(TableContext context, IMediator mediator)
        {
            _mediator = mediator;
            _context = context;
        }

       
        public async Task<int> SaveChangesAsync()
        {
            var result = await _context.SaveChangesAsync();

            await _mediator.DispatchDomainEvents(_context);
            return result;

        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Reset()
        {
            _context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);
        }
        public IRepositoryPipeAccesory RepositoryPipeAccesory => _RepositoryPipeAccesory ??= new RepositoryPipeAccesory(_context);
        public IRepositoryMWO RepositoryMWO => _RepositoryMWO ??= new RepositoryMWO(_context);
        public IRepositoryMWOType RepositoryMWOType => _RepositoryMWOType ??= new RepositoryMWOType(_context);
        public IRepositoryMWOItem RepositoryMWOItem => _RepositoryMWOItem ??= new RepositoryMWOItem(_context);
        public IRepositoryMWOItemWithEquipment RepositoryMWOItemWithEquipment => _RepositoryMWOItemWithEquipment ??= new RepositoryMWOItemWithEquipment(_context);
        public IRepositoryMWOItemWithInstrument RepositoryMWOItemWithInstrument => _RepositoryMWOItemWithInstrument ??= new RepositoryMWOItemWithInstrument(_context);
        public IRepositoryMWOItemWithPiping RepositoryMWOItemWithPiping => _RepositoryMWOItemWithPiping ??= new RepositoryMWOItemWithPiping(_context);
        public IRepositoryMWOItemWithNozzles RepositoryMWOItemWithNozzles => _RepositoryMWOItemWithNozzles ??= new RepositoryMWOItemWithNozzles(_context);

        public IRepositoryBrand RepositoryBrand => _RepositoryBrand ??= new RepositoryBrand(_context);
        public IRepositoryBrandSupplier RepositoryBrandSupplier => _RepositoryBrandSupplier ??= new RepositoryBrandSupplier(_context);
        public IRepositorySupplier RepositorySupplier => _RepositorySupplier ??= new RepositorySupplier(_context);
        public IRepositoryChapter RepositoryChapter => _RepositoryChapter ??= new RepositoryChapter(_context);
        public IRepositoryConnectionType RepositoryConnectionType => _RepositoryConnectionType ??= new RepositoryConnectionType(_context);
        public IRepositoryControlLoop RepositoryControlLoop => _RepositoryControlLoop ??= new RepositoryControlLoop(_context);

        public IRepositoryDeviceFunction RepositoryDeviceFunction => _RepositoryDeviceFunction ??= new RepositoryDeviceFunction(_context);

        public IRepositoryDeviceFunctionModifier RepositoryDeviceFunctionModifier => _RepositoryDeviceFunctionModifier ??= new RepositoryDeviceFunctionModifier(_context);

        public IRepositoryDownPayment RepositoryDownPayment => _RepositoryDownPayment ??= new RepositoryDownPayment(_context);

        public IRepositoryElectricalBox RepositoryElectricalBox => _RepositoryElectricalBox ??= new RepositoryElectricalBox(_context);

        public IRepositoryEntityUnit RepositoryEntityUnit => _RepositoryEntityUnit ??= new RepositoryEntityUnit(_context);

        public IRepositoryEquipmentType RepositoryEquipmentType => _RepositoryEquipmentType ??= new RepositoryEquipmentType(_context);

        public IRepositoryEquipmentTypeSub RepositoryEquipmentTypeSub => _RepositoryEquipmentTypeSub ??= new RepositoryEquipmentTypeSub(_context);

        public IRepositoryFieldLocation RepositoryFieldLocation => _RepositoryFieldLocation ??= new RepositoryFieldLocation(_context);
        public IRepositoryGasket RepositoryGasket => _RepositoryGasket ??= new RepositoryGasket(_context);
        public IRepositoryMaterial RepositoryMaterial => _RepositoryMaterial ??= new RepositoryMaterial(_context);
        public IRepositoryMeasuredVariable RepositoryMeasuredVariable => _RepositoryMeasuredVariable ??= new RepositoryMeasuredVariable(_context);
        public IRepositoryMeasuredVariableModifier RepositoryMeasuredVariableModifier => _RepositoryMeasuredVariableModifier ??= new RepositoryMeasuredVariableModifier(_context);
        public IRepositoryNozzle RepositoryNozzle => _RepositoryNozzle ??= new RepositoryNozzle(_context);
        public IRepositoryPipeClass RepositoryPipeClass => _RepositoryPipeClass ??= new RepositoryPipeClass(_context);

        public IRepositoryPipeDiameter RepositoryPipeDiameter => _RepositoryPipeDiameter ??= new RepositoryPipeDiameter(_context);

        public IRepositoryProcessCondition RepositoryProcessCondition => _RepositoryProcessCondition ??= new RepositoryProcessCondition(_context);

        public IRepositoryProcessFluid RepositoryProcessFluid => _RepositoryProcessFluid ??= new RepositoryProcessFluid(_context);

        public IRepositoryPropertyPackage RepositoryPropertyPackage => _RepositoryPropertyPackage ??= new RepositoryPropertyPackage(_context);

        public IRepositoryPurchaseOrder RepositoryPurchaseOrder => _RepositoryPurchaseOrder ??= new RepositoryPurchaseOrder(_context);

        public IRepositoryPurchaseOrderItem RepositoryPurchaseOrderItem => _RepositoryPurchaseOrderItem ??= new RepositoryPurchaseOrderItem(_context);

        public IRepositoryReadout RepositoryReadout => _RepositoryReadout ??= new RepositoryReadout(_context);

        public IRepositorySignal RepositorySignal => _RepositorySignal ??= new RepositorySignal(_context);

        public IRepositorySignalModifier RepositorySignalModifier => _RepositorySignalModifier ??= new RepositorySignalModifier(_context);

        public IRepositorySignalType RepositorySignalType => _RepositorySignalType ??= new RepositorySignalType(_context);

        public IRepositoryTaks RepositoryTaks => _RepositoryTaks ??= new RepositoryTaks(_context);

        public IRepositoryTaxCodeLD RepositoryTaxCodeLD => _RepositoryTaxCodeLD ??= new RepositoryTaxCodeLD(_context);

        public IRepositoryTaxCodeLP RepositoryTaxCodeLP => _RepositoryTaxCodeLP ??= new RepositoryTaxCodeLP(_context);

        public IRepositoryUnitaryBasePrize RepositoryUnitaryBasePrize => _RepositoryUnitaryBasePrize ??= new RepositoryUnitaryBasePrize(_context);

        public IRepositoryUser RepositoryUser => _RepositoryUser ??= new RepositoryUser(_context);

        public IRepositoryUserRequirement RepositoryUserRequirement => _RepositoryUserRequirement ??= new RepositoryUserRequirement(_context);

        public IRepositoryUserRequirementType RepositoryUserRequirementType => _RepositoryUserRequirementType ??= new RepositoryUserRequirementType(_context);

        public IRepositoryWire RepositoryWire => _RepositoryWire ??= new RepositoryWire(_context);
        public IRepositoryAlterationItem RepositoryAlterationItem => _RepositoryAlterationItem ??= new RepositoryAlterationItem(_context);
        public IRepositoryFoundationItem RepositoryFoundationItem => _RepositoryFoundationItem ??= new RepositoryFoundationItem(_context);
        public IRepositoryStructuralItem RepositoryStructuralItem => _RepositoryStructuralItem ??= new RepositoryStructuralItem(_context);
        public IRepositoryEquipmentItem RepositoryEquipmentItem => _RepositoryEquipmentItem ??= new RepositoryEquipmentItem(_context);
        public IRepositoryElectricalItem RepositoryElectricalItem => _RepositoryElectricalItem ??= new RepositoryElectricalItem(_context);
        public IRepositoryPipingItem RepositoryPipingItem => _RepositoryPipingItem ??= new RepositoryPipingItem(_context);
        public IRepositoryInstrumentItem RepositoryInstrumentItem => _RepositoryInstrumentItem ??= new RepositoryInstrumentItem(_context);
       public IRepositoryInsulationItem RepositoryInsulationItem => _RepositoryInsulationItem ??= new RepositoryInsulationItem(_context);
        public IRepositoryPaintingItem RepositoryPaintingItem => _RepositoryPaintingItem ??= new RepositoryPaintingItem(_context);
        public IRepositoryEHSItem RepositoryEHSItem => _RepositoryEHSItem ??= new RepositoryEHSItem(_context);
        public IRepositoryTaxesItem RepositoryTaxesItem => _RepositoryTaxesItem ??= new RepositoryTaxesItem(_context);
        public IRepositoryTestingItem RepositoryTestingItem => _RepositoryTestingItem ??= new RepositoryTestingItem(_context);
        public IRepositoryEngineeringCostItem RepositoryEngineeringCostItem => _RepositoryEngineeringCostItem ??= new RepositoryEngineeringCostItem(_context);
        public IRepositoryContingencyItem RepositoryContingencyItem => _RepositoryContingencyItem ??= new RepositoryContingencyItem(_context);

        public async Task<int> Complete()
        {
            return await SaveChangesAsync();
        }
    }
}
