using CPTool.Application.Contracts;
using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositorySignal : RepositoryBase<Signal>, IRepositorySignal
    {
        public RepositorySignal(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<Signal>> GetAllAsync()
        {
             var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()
                .Include(x=>x.SignalType)
                .Include(x => x.MWOItem)
                .Include(x => x.SignalModifier)
                .Include(x => x.Wire)
                .Include(x => x.FieldLocation)
                .Include(x => x.ElectricalBox)
                .Include(x => x.MWO)
                .Include(x => x.MWOItem)
                .Include(x => x.MWOItem).ThenInclude(x => x!.EquipmentItem)
                .Include(x => x.MWOItem).ThenInclude(x=>x!.EquipmentItem).ThenInclude(x=>x!.eEquipmentType)
                .Include(x => x.MWOItem).ThenInclude(x => x!.EquipmentItem).ThenInclude(x => x!.eEquipmentTypeSub)
                .Include(x => x.MWOItem).ThenInclude(x => x!.InstrumentItem)
                .Include(x => x.MWOItem).ThenInclude(x => x!.InstrumentItem).ThenInclude(x=>x!.DeviceFunction)
                .Include(x => x.MWOItem).ThenInclude(x => x!.InstrumentItem).ThenInclude(x => x!.DeviceFunctionModifier)
                .Include(x => x.MWOItem).ThenInclude(x => x!.InstrumentItem).ThenInclude(x => x!.Readout)
                .Include(x => x.MWOItem).ThenInclude(x => x!.InstrumentItem).ThenInclude(x => x!.MeasuredVariable)
                .Include(x => x.MWOItem).ThenInclude(x => x!.InstrumentItem).ThenInclude(x => x!.MeasuredVariableModifier)

                .ToListAsync();
            return result;
        }
        public override async Task<Signal> GetByIdAsync(int id)
        {



            var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()
                .Include(x => x.SignalType)
                .Include(x => x.MWOItem)
                .Include(x => x.SignalModifier)
                .Include(x => x.Wire)
                .Include(x => x.FieldLocation)
                .Include(x => x.ElectricalBox)
                .Include(x => x.MWO)
                .Include(x => x.MWOItem)
                .Include(x => x.MWOItem).ThenInclude(x => x!.EquipmentItem)
                .Include(x => x.MWOItem).ThenInclude(x => x!.EquipmentItem).ThenInclude(x => x!.eEquipmentType)
                .Include(x => x.MWOItem).ThenInclude(x => x!.EquipmentItem).ThenInclude(x => x!.eEquipmentTypeSub)
                .Include(x => x.MWOItem).ThenInclude(x => x!.InstrumentItem)
                .Include(x => x.MWOItem).ThenInclude(x => x!.InstrumentItem).ThenInclude(x => x!.DeviceFunction)
                .Include(x => x.MWOItem).ThenInclude(x => x!.InstrumentItem).ThenInclude(x => x!.DeviceFunctionModifier)
                .Include(x => x.MWOItem).ThenInclude(x => x!.InstrumentItem).ThenInclude(x => x!.Readout)
                .Include(x => x.MWOItem).ThenInclude(x => x!.InstrumentItem).ThenInclude(x => x!.MeasuredVariable)
                .Include(x => x.MWOItem).ThenInclude(x => x!.InstrumentItem).ThenInclude(x => x!.MeasuredVariableModifier)

              .FirstOrDefaultAsync(x => x.Id == id);
            return result!;
        }
    }
}
