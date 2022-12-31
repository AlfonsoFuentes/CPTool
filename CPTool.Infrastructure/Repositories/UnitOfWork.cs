


using CPTool.Application.Contracts;

namespace CPTool.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        IRepositoryBrand _RepositoryBrand= null!;
        IRepositoryBrandSupplier _RepositoryBrandSupplier= null!;

        IRepositoryChapter _RepositoryChapter= null!;
        IRepositoryConnectionType _RepositoryConnectionType = null!;
        IRepositoryControlLoop _RepositoryControlLoop= null!;
        IRepositoryDeviceFunction _RepositoryDeviceFunction= null!;
        IRepositoryDeviceFunctionModifier _RepositoryDeviceFunctionModifier= null!;
        IRepositoryDownPayment _RepositoryDownPayment= null!;
        IRepositoryElectricalBox _RepositoryElectricalBox= null!;
        IRepositoryEntityUnit _RepositoryEntityUnit= null!;
        IRepositoryEquipmentType _RepositoryEquipmentType= null!;
        IRepositoryGasket _RepositoryGasket = null!;
        IRepositoryEquipmentTypeSub _RepositoryEquipmentTypeSub= null!;
        IRepositoryFieldLocation _RepositoryFieldLocation= null!;
        IRepositoryMaterial _RepositoryMaterial = null!;
        IRepositoryMeasuredVariable _RepositoryMeasuredVariable = null!;
        IRepositoryMeasuredVariableModifier _RepositoryMeasuredVariableModifier = null!;
        IRepositoryMWO _RepositoryMWO= null!;
        IRepositoryMWOType _RepositoryMWOType = null!;
        IRepositoryMWOItem _RepositoryMWOItem= null!;
        IRepositoryNozzle _RepositoryNozzle = null!;
        IRepositoryPipeAccesory _RepositoryPipeAccesory= null!;
        IRepositoryPipeClass _RepositoryPipeClass= null!;
        IRepositoryPipeDiameter _RepositoryPipeDiameter= null!;
        IRepositoryProcessCondition _RepositoryProcessCondition= null!;
        IRepositoryProcessFluid _RepositoryProcessFluid= null!;
        IRepositoryPropertyPackage _RepositoryPropertyPackage= null!;

        IRepositoryPurchaseOrder _RepositoryPurchaseOrder= null!;
        IRepositoryPurchaseOrderItem _RepositoryPurchaseOrderItem= null!;
        IRepositoryReadout _RepositoryReadout= null!;
        IRepositorySignal _RepositorySignal= null!;
        IRepositorySignalModifier _RepositorySignalModifier= null!;
        IRepositorySignalType _RepositorySignalType= null!;
        IRepositorySupplier _RepositorySupplier= null!;
        IRepositoryTaks _RepositoryTaks= null!;
        IRepositoryTaxCodeLD _RepositoryTaxCodeLD= null!;
        IRepositoryTaxCodeLP _RepositoryTaxCodeLP= null!;
        IRepositoryUnitaryBasePrize _RepositoryUnitaryBasePrize= null!;
        IRepositoryUser _RepositoryUser= null!;
        IRepositoryUserRequirement _RepositoryUserRequirement= null!;
        IRepositoryUserRequirementType _RepositoryUserRequirementType= null!;
        IRepositoryWire _RepositoryWire = null!;

        private Hashtable _repository = null!;
        private readonly TableContext _context;

        
       


        
        public UnitOfWork(TableContext context)
        {

            _context = context;
        }
       
        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : AuditableEntity
        {
            if (_repository == null)
            {
                _repository = new();
            }
            var type = typeof(TEntity);
            if (!_repository.ContainsKey(type))
            {
                var repositorytype = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(
                    repositorytype.MakeGenericType(typeof(TEntity)), _context);
                _repository.Add(type, repositoryInstance);
            }
            var response = (IAsyncRepository<TEntity>)_repository[type]!;
            return response;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();

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

        public IRepositoryAlterationItem RepositoryAlterationItem => throw new NotImplementedException();

        public IRepositoryFoundationItem RepositoryFoundationItem => throw new NotImplementedException();

        public IRepositoryStructuralItem RepositoryStructuralItem => throw new NotImplementedException();

        public IRepositoryEquipmentItem RepositoryEquipmentItem => throw new NotImplementedException();

        public IRepositoryElectricalItem RepositoryElectricalItem => throw new NotImplementedException();

        public IRepositoryPipingItem RepositoryPipingItem => throw new NotImplementedException();

        public IRepositoryInstrumentItem RepositoryInstrumentItem => throw new NotImplementedException();

        public IRepositoryInsulationItem RepositoryInsulationItem => throw new NotImplementedException();

        public IRepositoryPaintingItem RepositoryPaintingItem => throw new NotImplementedException();

        public IRepositoryEHSItem RepositoryEHSItem => throw new NotImplementedException();

        public IRepositoryTaxesItem RepositoryTaxesItem => throw new NotImplementedException();

        public IRepositoryTestingItem RepositoryTestingItem => throw new NotImplementedException();

        public IRepositoryEngineeringCostItem RepositoryEngineeringCostItem => throw new NotImplementedException();

        public IRepositoryContingencyItem RepositoryContingencyItem => throw new NotImplementedException();
    }
}
