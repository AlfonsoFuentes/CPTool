using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.Persistence.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;
        Task<int> Complete();
        IRepositoryBrand RepositoryBrand { get; }
        IRepositoryBrandSupplier RepositoryBrandSupplier { get; }

        IRepositoryChapter RepositoryChapter { get; }
        IRepositoryConnectionType RepositoryConnectionType { get; }
        IRepositoryControlLoop RepositoryControlLoop { get; }
        IRepositoryDeviceFunction RepositoryDeviceFunction { get; }
        IRepositoryDeviceFunctionModifier RepositoryDeviceFunctionModifier { get; }
        IRepositoryDownPayment RepositoryDownPayment { get; }
        IRepositoryElectricalBox RepositoryElectricalBox { get; }
        IRepositoryEntityUnit RepositoryEntityUnit { get; }
        IRepositoryEquipmentType RepositoryEquipmentType { get; }

        IRepositoryEquipmentTypeSub RepositoryEquipmentTypeSub { get; }
        IRepositoryFieldLocation RepositoryFieldLocation { get; }
        IRepositoryGasket RepositoryGasket { get; }
        IRepositoryMaterial RepositoryMaterial { get; }
        IRepositoryMeasuredVariable RepositoryMeasuredVariable { get; }
        IRepositoryMeasuredVariableModifier RepositoryMeasuredVariableModifier { get; }
        IRepositoryMWO RepositoryMWO { get; }
        IRepositoryMWOType RepositoryMWOType { get; }
        IRepositoryMWOItem RepositoryMWOItem { get; }
        IRepositoryNozzle RepositoryNozzle { get; }
        IRepositoryPipeAccesory RepositoryPipeAccesory { get; }
        IRepositoryPipeClass RepositoryPipeClass { get; }
        IRepositoryPipeDiameter RepositoryPipeDiameter { get; }
        IRepositoryProcessCondition RepositoryProcessCondition { get; }
        IRepositoryProcessFluid RepositoryProcessFluid { get; }
        IRepositoryPropertyPackage RepositoryPropertyPackage { get; }

        IRepositoryPurchaseOrder RepositoryPurchaseOrder { get; }
        IRepositoryPurchaseOrderItem RepositoryPurchaseOrderItem { get; }
        IRepositoryReadout RepositoryReadout { get; }
        IRepositorySignal RepositorySignal { get; }
        IRepositorySignalModifier RepositorySignalModifier { get; }
        IRepositorySignalType RepositorySignalType { get; }
        IRepositorySupplier RepositorySupplier { get; }
        IRepositoryTaks RepositoryTaks { get; }
        IRepositoryTaxCodeLD RepositoryTaxCodeLD { get; }
        IRepositoryTaxCodeLP RepositoryTaxCodeLP { get; }
        IRepositoryUnitaryBasePrize RepositoryUnitaryBasePrize { get; }
        IRepositoryUser RepositoryUser { get; }
        IRepositoryUserRequirement RepositoryUserRequirement { get; }
        IRepositoryUserRequirementType RepositoryUserRequirementType { get; }
        IRepositoryWire RepositoryWire { get; }

      
       
       


        void Reset();
    }
}
