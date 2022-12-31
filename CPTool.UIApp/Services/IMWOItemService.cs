
using CPTool.ApplicationCQRS.Features.Brands.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Chapters.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.DeviceFunctionModifiers.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.DeviceFunctions.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.EquipmentTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.EquipmentTypeSubs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Gaskets.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Materials.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MeasuredVariableModifiers.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MeasuredVariables.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOItems.Queries.Export;
using CPTool.ApplicationCQRS.Features.MWOItems.Queries.GetListWithNozzles;
using CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Nozzles.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PipeClasss.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PipeDiameters.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PipingItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.ProcessConditions.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.ProcessFluids.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PurchaseOrders.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Readouts.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Suppliers.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.UnitaryBasePrizes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using CPTool.ApplicationCQRSFeatures.Brands.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.Chapters.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.DeviceFunctionModifiers.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.DeviceFunctions.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.EquipmentItems.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.EquipmentTypes.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.EquipmentTypeSubs.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.Gaskets.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.Materials.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.MeasuredVariableModifiers.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.MeasuredVariables.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.MWOItems.Commands.Delete;
using CPTool.ApplicationCQRSFeatures.MWOItems.Queries.GetDetail;
using CPTool.ApplicationCQRSFeatures.MWOItems.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.Nozzles.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.PipeClasss.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.PipeDiameters.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.ProcessFluids.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.PurchaseOrderItems.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.PurchaseOrders.Queries.GetDetail;
using CPTool.ApplicationCQRSFeatures.PurchaseOrders.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.Readouts.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.Signals.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.Suppliers.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.UnitaryBasePrizes.Queries.GetList;
using CPTool.Domain.Entities;
using CPTool.Domain.Enums;
using MediatR;
using System.Collections.Generic;

namespace CPTool.UIApp.Services
{
    public class MWOItemDialogData
    {
        public List<CommandChapter> Chapters { get; set; } = new();
        public List<CommandUnitaryBasePrize> UnitaryBasePrizes { get; set; } = new();
        public List<CommandEquipmentType> EquipmentTypes { get; set; } = new();
        public List<CommandEquipmentTypeSub> EquipmentTypeSubs { get; set; } = new();
        public List<CommandBrand> Brands { get; set; } = new();
        public List<CommandSupplier> Suppliers { get; set; } = new();
        public List<CommandGasket> Gaskets { get; set; } = new();
        public List<CommandMaterial> Materials { get; set; } = new();
        public List<CommandMeasuredVariable> MeasuredVariables { get; set; } = new();
        public List<CommandMeasuredVariableModifier> MeasuredVariableModifiers { get; set; } = new();
        public List<CommandReadout> Readouts { get; set; } = new();
        public List<CommandDeviceFunction> DeviceFunctions { get; set; } = new();

        public List<CommandDeviceFunctionModifier> DeviceFunctionModifiers { get; set; } = new();

        public List<CommandPipeClass> PipeClasses { get; set; } = new();
        public List<CommandPipeDiameter> PipeDiameters { get; set; } = new();
        public List<CommandProcessFluid> ProcessFluids { get; set; } = new();
        public List<CommandMWOItem> MWOItemsStarts { get; set; } = new();
        public List<CommandNozzle> NozzlesByMWOItemsStarts { get; set; } = new();
        public List<CommandMWOItem> MWOItemsFinish { get; set; } = new();
        public List<CommandNozzle> NozzlesByMWOItemsFinish { get; set; } = new();

        public List<CommandPurchaseOrder> PurchaseOrders { get; set; } = new();

        public CommandNozzle OriginalNozzlePipeStart { get; set; } = new();
        public CommandNozzle OriginalNozzlePipeFinish { get; set; } = new();
        public double SumBudget { get; set; } = 0;
        public double SumAssigned { get; set; } = 0;
        public double SumActual { get; set; } = 0;
        public double SumCommitment { get; set; } = 0;
        public double SumPending { get; set; } = 0;
        public void GetSummary(List<CommandMWOItem> Elements)
        {
            SumBudget = Elements.Count == 0 ? 0 : Elements.Sum(y => y.BudgetPrize);
            SumAssigned = Elements.Count == 0 ? 0 : Elements.Sum(y => y.Assigned);
            SumActual = Elements.Count == 0 ? 0 : Elements.Sum(y => y.Actual);
            SumCommitment = Elements.Count == 0 ? 0 : Elements.Sum(y => y.Commitment);
            SumPending = Elements.Count == 0 ? 0 : Elements.Sum(y => y.Pending);
        }

    }
    public interface IMWOItemService
    {
        Task<DeleteMWOItemCommandResponse> Delete(int id);
        Task<MWOItemCommandResponse> AddUpdate(CommandMWOItem command);

        Task<CommandMWOItem> GetById(int id);
        Task<bool> VerifyProcessCondition(CommandMWOItem command);
        Task<List<CommandMWOItem>> GetAll(int MWOId);

        Task<ExportBaseResponse> GetFiletoExport(string type);
        Task<MWOItemDialogData> GetMWOItemDataDialog();
        Task<MWOItemDialogData> GetMWOItemDataDialogByModel(MWOItemDialogData dialogdata, CommandMWOItem Model);
        Task<List<CommandSupplier>> GetSupliersByBrand(int BrandId);
        Task<List<CommandEquipmentTypeSub>> GetEquipmentTypeSubByEquipmentType(int equipmentypeid);

        Task<List<CommandPipeDiameter>> GetPipeDiameterByPipeClass(int pipeclasid);
        Task<MWOItemDialogData> GetMWOItemDataDialogByChapter(MWOItemDialogData dataResponse, CommandMWOItem Model);
        Task<MWOItemDialogData> GetMWOItemDataDialogByChapterByModel(MWOItemDialogData dataResponse, CommandMWOItem Model);
        Task<List<CommandMWOItem>> GetMWOItemsFinish(CommandMWO MWO);
        Task<List<CommandMWOItem>> GetMWOItemsStarts(CommandMWO MWO);
        Task<List<CommandMWOItem>> GetMWOItemsStartsByModel(CommandMWOItem Model);
        Task<List<CommandMWOItem>> GetMWOItemsFinishByModel(CommandMWOItem Model);
        Task<MWOItemDialogData> GetMWOItemsStartFinish(MWOItemDialogData dataResponse, CommandMWOItem Model);
        Task VerifyNozzlesClosing(MWOItemDialogData dataResponse, CommandMWOItem Model);
        MWOItemDialogData OnChangeEquipmentFinish(MWOItemDialogData dataResponse, CommandPipingItem Model);
        MWOItemDialogData OnChangeEquipmentStart(MWOItemDialogData dataResponse, CommandPipingItem Model);
    }
    public class MWOItemService : IMWOItemService
    {
        protected readonly IMediator mediator;

        public MWOItemService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<DeleteMWOItemCommandResponse> Delete(int id)
        {
            DeleteMWOItemCommand deletecommand = new();
            deletecommand.Id = id;
            var retorno = await mediator.Send(deletecommand);

            return retorno;

        }

        public async Task<MWOItemCommandResponse> AddUpdate(CommandMWOItem command)
        {
            return await mediator.Send(command);
        }

        public async Task<CommandMWOItem> GetById(int id)
        {
            GetMWOItemDetailQuery command = new();
            command.Id = id;
            return await mediator.Send(command);
        }

        public async Task<List<CommandMWOItem>> GetAll(int MWOId)
        {
            GetMWOItemsListQuery command = new()
            {
                MWOId = MWOId,

            };

            return await mediator.Send(command);
        }



        public async Task<ExportBaseResponse> GetFiletoExport(string type)
        {
            ExportMWOItemsQuery export = new();
            export.Type = type;
            return await mediator.Send(export);

        }
        public async Task<MWOItemDialogData> GetMWOItemDataDialog()
        {
            MWOItemDialogData dataResponse = new();

            GetChaptersListQuery chapter = new();
            dataResponse.Chapters = await mediator.Send(chapter);

            GetUnitaryBasePrizesListQuery unitary = new();

            dataResponse.UnitaryBasePrizes = await mediator.Send(unitary);



            return dataResponse;
        }
        public async Task<MWOItemDialogData> GetMWOItemDataDialogByChapter(MWOItemDialogData dataResponse, CommandMWOItem Model)
        {
            switch (Model.ChapterId)
            {
                case 4: return await GetDataByEquipment(dataResponse);
                case 6: return await GetDataByPiping(dataResponse, Model.MWO);
                case 7: return await GetDataByInstrument(dataResponse);

            }

            return dataResponse;
        }
        public async Task<MWOItemDialogData> GetDataByEquipment(MWOItemDialogData dataResponse)
        {
            GetEquipmentTypesListQuery equipment = new();
            dataResponse.EquipmentTypes = await mediator.Send(equipment);
            GetBrandsListQuery brand = new();
            dataResponse.Brands = await mediator.Send(brand);
            GetGasketsListQuery gasket = new();
            dataResponse.Gaskets = await mediator.Send(gasket);
            GetMaterialsListQuery material = new();
            dataResponse.Materials = await mediator.Send(material);

            GetProcessFluidsListQuery pf = new();
            dataResponse.ProcessFluids = await mediator.Send(pf);

            return dataResponse;
        }
        public async Task<MWOItemDialogData> GetDataByInstrument(MWOItemDialogData dataResponse)
        {

            GetBrandsListQuery brand = new();
            dataResponse.Brands = await mediator.Send(brand);
            GetDeviceFunctionsListQuery df = new();
            dataResponse.DeviceFunctions = await mediator.Send(df);
            GetDeviceFunctionModifiersListQuery dfm = new();
            dataResponse.DeviceFunctionModifiers = await mediator.Send(dfm);
            GetReadoutsListQuery rd = new();
            dataResponse.Readouts = await mediator.Send(rd);
            GetMeasuredVariablesListQuery mv = new();
            dataResponse.MeasuredVariables = await mediator.Send(mv);
            GetMeasuredVariableModifiersListQuery vmm = new();
            dataResponse.MeasuredVariableModifiers = await mediator.Send(vmm);
            GetGasketsListQuery gasket = new();
            dataResponse.Gaskets = await mediator.Send(gasket);
            GetMaterialsListQuery material = new();
            dataResponse.Materials = await mediator.Send(material);
            GetProcessFluidsListQuery pf = new();
            dataResponse.ProcessFluids = await mediator.Send(pf);
            return dataResponse;
        }
        public async Task<MWOItemDialogData> GetDataByPiping(MWOItemDialogData dataResponse, CommandMWO MWO)
        {
            GetPipeClasssListQuery pipeclass = new();
            dataResponse.PipeClasses = await mediator.Send(pipeclass);

            GetProcessFluidsListQuery pf = new();
            dataResponse.ProcessFluids = await mediator.Send(pf);
            GetMaterialsListQuery material = new();
            dataResponse.Materials = await mediator.Send(material);





            return dataResponse;
        }
        public async Task<List<CommandMWOItem>> GetMWOItemsStarts(CommandMWO MWO)
        {
            GetMWOItemWithNozzlesListItemQuery getitemstart = new()
            {
                MWOId = MWO.Id,
                type = Domain.Enums.StreamType.Outlet,

            };

            var result = await mediator.Send(getitemstart);
            return result;
        }
        public async Task<List<CommandMWOItem>> GetMWOItemsFinish(CommandMWO MWO)
        {
            GetMWOItemWithNozzlesListItemQuery getitemstart = new()
            {
                MWOId = MWO.Id,
                type = Domain.Enums.StreamType.Inlet,

            };

            var result = await mediator.Send(getitemstart);
            return result;
        }
        public async Task<List<CommandMWOItem>> GetMWOItemsStartsByModel(CommandMWOItem Model)
        {
            GetMWOItemWithNozzlesListItemQuery getitemstart = new()
            {
                MWOId = Model.MWO.Id,
                type = Domain.Enums.StreamType.Outlet,
                ModelId = Model.Id

            };

            var result = await mediator.Send(getitemstart);
            return result;
        }
        public async Task<List<CommandMWOItem>> GetMWOItemsFinishByModel(CommandMWOItem Model)
        {
            GetMWOItemWithNozzlesListItemQuery getitemstart = new()
            {
                MWOId = Model.MWO.Id,
                type = Domain.Enums.StreamType.Inlet,
                ModelId = Model.Id

            };

            var result = await mediator.Send(getitemstart);
            return result;
        }
        public async Task<MWOItemDialogData> GetMWOItemDataDialogByModel(MWOItemDialogData dataResponse, CommandMWOItem Model)
        {

            if (Model.Chapter != null)
            {
                await GetMWOItemDataDialogByChapter(dataResponse, Model);
                await GetMWOItemDataDialogByChapterByModel(dataResponse, Model);
            }


            dataResponse.PurchaseOrders = await GetPurchaseOrderInMWOItem(Model);


            return dataResponse;
        }

        public async Task<MWOItemDialogData> GetMWOItemDataDialogByChapterByModel(MWOItemDialogData dataResponse, CommandMWOItem Model)
        {

            switch (Model.ChapterId)
            {
                case 4: return await GetDataByEquipmentByModel(dataResponse, Model);
                case 6: return await GetDataByPipingByModel(dataResponse, Model);
                case 7: return await GetDataByInstrumentByModel(dataResponse, Model);

            }

            return dataResponse;
        }

        public Task<List<CommandSupplier>> GetSupliersByBrand(int BrandId)
        {
            GetSuppliersListQuery getList = new()
            {
                BrandId = BrandId,
            };
            return mediator.Send(getList);
        }
        public Task<List<CommandEquipmentTypeSub>> GetEquipmentTypeSubByEquipmentType(int equipmentypeid)
        {
            GetEquipmentTypeSubsListQuery getList = new()
            {
                EquipmentTypeId = equipmentypeid,
            };
            return mediator.Send(getList);
        }


        public async Task<MWOItemDialogData> GetDataByEquipmentByModel(MWOItemDialogData dataResponse, CommandMWOItem Model)
        {

            if (Model.EquipmentItemId != 0)
            {
                if (Model.EquipmentItem.eEquipmentTypeId != null)
                {
                    dataResponse.EquipmentTypeSubs = await GetEquipmentTypeSubByEquipmentType(Model.EquipmentItem.eEquipmentTypeId.Value);
                }

                if (Model.EquipmentItem.eBrandId != null)
                {
                    dataResponse.Suppliers = await GetSupliersByBrand(Model.EquipmentItem.eBrandId.Value);
                }
                //foreach (var row in Model.EquipmentItem.Nozzles)
                //{
                //    if (row.ConnectedToId != null)
                //    {
                //        GetMWOItemDetailQuery query = new() { Id = row.ConnectedToId.Value };
                //        row.ConnectedTo = await mediator.Send(query);
                //    }
                //}

            }


            return dataResponse;
        }
        public async Task<MWOItemDialogData> GetDataByInstrumentByModel(MWOItemDialogData dataResponse, CommandMWOItem Model)
        {


            if (Model.InstrumentItemId != 0)
            {

                if (Model.InstrumentItem.iBrandId != null)
                {
                    dataResponse.Suppliers = await GetSupliersByBrand(Model.InstrumentItem.iBrandId.Value);
                }

                //foreach (var row in Model.InstrumentItem.Nozzles)
                //{
                //    if (row.ConnectedToId != null)
                //    {
                //        GetMWOItemDetailQuery query = new() { Id = row.ConnectedToId.Value };
                //        row.ConnectedTo = await mediator.Send(query);
                //    }
                //}
            }
            return dataResponse;
        }
        public async Task<MWOItemDialogData> GetDataByPipingByModel(MWOItemDialogData dataResponse, CommandMWOItem Model)
        {

            dataResponse = await GetMWOItemsStartFinish(dataResponse, Model);
            if (Model.PipingItemId != 0)
            {

                if (Model.PipingItem.pPipeClassId != null)
                {
                    dataResponse.PipeDiameters = await GetPipeDiameterByPipeClass(Model.PipingItem.pPipeClassId.Value);
                }



            }


            return dataResponse;
        }
        public async Task<MWOItemDialogData> GetMWOItemsStartFinish(MWOItemDialogData dataResponse, CommandMWOItem Model)
        {
            if (Model.Id == 0)
            {
                dataResponse.MWOItemsStarts = await GetMWOItemsStarts(Model.MWO);
                dataResponse.MWOItemsFinish = await GetMWOItemsFinish(Model.MWO);
            }
            else
            {
                dataResponse.MWOItemsStarts = await GetMWOItemsStartsByModel(Model);
                dataResponse.MWOItemsFinish = await GetMWOItemsFinishByModel(Model);
            }


            if (Model.PipingItem.StartMWOItem != null && Model.PipingItem.StartMWOItem.Id != 0)
            {
                Model.PipingItem.StartMWOItem = dataResponse.MWOItemsStarts.FirstOrDefault(x => x.Id == Model.PipingItem.StartMWOItem.Id);

                dataResponse.NozzlesByMWOItemsStarts = Model.PipingItem.StartMWOItem.Nozzles.Where(x => x.StreamType == StreamType.Outlet).ToList();
                if (Model.PipingItem.NozzleStart != null)
                {
                    Model.PipingItem.NozzleStart = dataResponse.NozzlesByMWOItemsStarts.FirstOrDefault(x => x.Id == Model.PipingItem.NozzleStart.Id);
                    dataResponse.OriginalNozzlePipeStart = Model.PipingItem.NozzleStart;
                }

            }
            if (Model.PipingItem.FinishMWOItem != null && Model.PipingItem.FinishMWOItem.Id != 0)
            {
                Model.PipingItem.FinishMWOItem = dataResponse.MWOItemsFinish.FirstOrDefault(x => x.Id == Model.PipingItem.FinishMWOItem.Id);
                dataResponse.NozzlesByMWOItemsFinish = Model.PipingItem.FinishMWOItem.Nozzles.Where(x => x.StreamType == StreamType.Inlet).ToList();

                if (Model.PipingItem.NozzleFinish != null)
                {
                    Model.PipingItem.NozzleFinish = dataResponse.NozzlesByMWOItemsFinish.FirstOrDefault(x => x.Id == Model.PipingItem.NozzleFinish.Id);
                    dataResponse.OriginalNozzlePipeFinish = Model.PipingItem.NozzleFinish;
                }


            }
            return dataResponse;
        }
        public async Task<List<CommandPipeDiameter>> GetPipeDiameterByPipeClass(int pipeclasid)
        {
            GetPipeDiametersListQuery pd = new()
            {
                PipeClassId = pipeclasid,
            };
            return await mediator.Send(pd);
        }

        public async Task<List<CommandPurchaseOrder>> GetPurchaseOrderInMWOItem(CommandMWOItem Model)
        {
            if (Model.Id == 0) return new();

            GetPurchaseOrderItemsListQuery poitems = new() { MWOItemId = Model.Id };
            var list = await mediator.Send(poitems);

            List<CommandPurchaseOrder> response = new();
            foreach (var item in list.Select(x => x.PurchaseOrder))
            {
                GetPurchaseOrderDetailQuery detail = new() { Id = item.Id };
                response.Add(await mediator.Send(detail));
            }
            return response;
        }

        public async Task<bool> VerifyProcessCondition(CommandMWOItem command)
        {
            switch (command.ChapterId)
            {
                case 4:
                    if (command.EquipmentItem.eProcessCondition == null)
                    {
                        command.EquipmentItem.eProcessCondition = new();

                        await AddUpdate(command);
                        return true;
                    }
                    else if (command.EquipmentItem.eProcessCondition.Density == null)
                    {
                        command.EquipmentItem.eProcessCondition = new();

                        await AddUpdate(command);
                        return true;
                    }
                    break;
                case 6:
                    if (command.PipingItem.pProcessCondition == null)
                    {
                        command.PipingItem.pProcessCondition = new();

                        await AddUpdate(command);
                        return true;
                    }
                    else if (command.PipingItem.pProcessCondition.Density == null)
                    {
                        command.PipingItem.pProcessCondition = new();

                        await AddUpdate(command);
                        return true;
                    }
                    break;
                case 7:
                    if (command.InstrumentItem.iProcessCondition == null)
                    {
                        command.InstrumentItem.iProcessCondition = new();

                        await AddUpdate(command);
                        return true;
                    }
                    else if (command.InstrumentItem.iProcessCondition.Density == null)
                    {
                        command.InstrumentItem.iProcessCondition = new();

                        await AddUpdate(command);
                        return true;
                    }
                    break;
            }
            return false;
        }

        public async Task VerifyNozzlesClosing(MWOItemDialogData dataResponse, CommandMWOItem Model)
        {

            if (Model.Id != 0)
            {
                await UpdateNozzleConnected(dataResponse.OriginalNozzlePipeStart, Model.PipingItem.NozzleStart, Model);

                await UpdateNozzleConnected(dataResponse.OriginalNozzlePipeFinish, Model.PipingItem.NozzleFinish, Model);



            }
        }

        async Task UpdateNozzleConnected(CommandNozzle Original, CommandNozzle NozzlePiping, CommandMWOItem Model)
        {
            if (Original != null)
            {
                if (Original.ConnectedTo != null && Original.ConnectedTo.Id != 0)
                {
                    if (NozzlePiping.Id == 0)
                    {
                        Original.ConnectedTo = null;
                        await mediator.Send(Original);
                    }
                    else if(NozzlePiping.Id!= Original.Id)
                    {
                        Original.ConnectedTo = null;
                        await mediator.Send(Original);
                    }
                }
            }

            if (NozzlePiping != null)
            {
                //Caso1: No estaba conectada tuberia a nadie
                if (NozzlePiping.Id != 0)
                {
                    NozzlePiping.ConnectedTo = Model;
                    await mediator.Send(NozzlePiping);
                }
                

            }

        }
       public MWOItemDialogData OnChangeEquipmentStart(MWOItemDialogData dataResponse, CommandPipingItem Model)
        {

            if (Model.NozzleStart != null && Model.NozzleStart.Id != 0)
            {
                Model.NozzleStart = null;



            }


            if (Model.StartMWOItem.Id != 0)
            {

                Model.StartMWOItem = dataResponse.MWOItemsStarts.FirstOrDefault(x => x.Id == Model.StartMWOItem.Id);
                dataResponse.NozzlesByMWOItemsStarts = Model.StartMWOItem.Nozzles.Where(x => x.StreamType == StreamType.Outlet).ToList();

            }
            else
            {


                dataResponse.NozzlesByMWOItemsStarts = new();
            }

            return dataResponse;
        }
        public MWOItemDialogData OnChangeEquipmentFinish(MWOItemDialogData dataResponse, CommandPipingItem Model)
        {
            if (Model.NozzleFinish != null && Model.NozzleFinish.Id != 0)
            {
                Model.NozzleFinish = null;


            }
            if (Model.FinishMWOItem.Id != 0)
            {
                Model.FinishMWOItem = dataResponse.MWOItemsFinish.FirstOrDefault(x => x.Id == Model.FinishMWOItem.Id);
                dataResponse.NozzlesByMWOItemsFinish = Model.FinishMWOItem.Nozzles.Where(x => x.StreamType == StreamType.Inlet).ToList();
            }
            else
            {

                dataResponse.NozzlesByMWOItemsFinish = new();
            }

            return dataResponse;

        }
    }
}
