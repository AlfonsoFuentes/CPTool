using CPTool.Domain.Common;
using CPTool.Persistence.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
  
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
        IRepositoryMWOItemWithNozzles RepositoryMWOItemWithNozzles { get; }
        IRepositorySpecification RepositorySpecification { get; }
        IRepositoryPropertySpecification RepositoryPropertySpecification { get; }   
       
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
