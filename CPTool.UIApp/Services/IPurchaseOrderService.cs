﻿using CPTool.ApplicationCQRS.Features.Brands.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.ProcessFluids.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PurchaseOrderItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PurchaseOrders.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PurchaseOrders.Queries.Export;
using CPTool.ApplicationCQRS.Features.Suppliers.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using CPTool.ApplicationCQRSFeatures.Brands.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.MWOItems.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.MWOs.Queries.GetDetail;
using CPTool.ApplicationCQRSFeatures.PurchaseOrders.Commands.Delete;
using CPTool.ApplicationCQRSFeatures.PurchaseOrders.Queries.GetDetail;
using CPTool.ApplicationCQRSFeatures.PurchaseOrders.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.Suppliers.Queries.GetList;
using CPTool.Domain.Entities;
using CPTool.Domain.Enums;
using CPTool.Services;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.Services
{
    public class PurchaseOrderDialogData
    {
        public List<CommandBrand> Brands { get; set; } = new();
        public List<CommandSupplier> Suppliers { get; set; } = new();
        public List<CommandMWOItem> MWOItemsOriginal { get; set; } = new();

        public string ButtonName { get; set; } = string.Empty;
        public bool DisableButtonSave { get; set; } = false;
        public double USDCOP { get; set; }
        public double USDEUR { get; set; }
       

        public bool InlineEdit { get; set; } = false;

    }
    public interface IPurchaseOrderService
    {
        Task<DeletePurchaseOrderCommandResponse> Delete(int id);
        Task<PurchaseOrderCommandResponse> AddUpdate(CommandPurchaseOrder command);

        Task<CommandPurchaseOrder> GetById(int id);

        Task<List<CommandPurchaseOrder>> GetAll(int MWOId);

        Task<ExportBaseResponse> GetFiletoExport(string type, List<CommandPurchaseOrder> List);
        Task<PurchaseOrderDialogData> GetPurchaseOrderDataDialog(CommandPurchaseOrder Model);
        Task<List<CommandSupplier>> GetSupplierByBrand(int brandId);
        CommandPurchaseOrderItem GetDataForAddItem(CommandMWOItem MWOItem, CommandPurchaseOrder Model);
        void AddPurchaseOrderItemToMWOItem(CommandPurchaseOrder Model, CommandPurchaseOrderItem purchaseOrderItem, PurchaseOrderDialogData data);
        void RemovePurchaseOrderItemFromMWOItem(CommandPurchaseOrder Model, PurchaseOrderDialogData data, int mwoitemid);
        bool DisableButtonSave(CommandPurchaseOrder Model);
    }
    public class PurchaseOrderService : IPurchaseOrderService
    {

        public ICurrencyApi _CurrencyService { get; set; }
        protected readonly IMediator mediator;

        public PurchaseOrderService(IMediator mediator, ICurrencyApi CurrencyService)
        {
            this.mediator = mediator;
            _CurrencyService = CurrencyService;
        }

        public async Task<DeletePurchaseOrderCommandResponse> Delete(int id)
        {
            DeletePurchaseOrderCommand deletecommand = new();
            deletecommand.Id = id;
            var retorno = await mediator.Send(deletecommand);

            return retorno;

        }

        public async Task<PurchaseOrderCommandResponse> AddUpdate(CommandPurchaseOrder command)
        {
           
            return await mediator.Send(command);
        }

        public async Task<CommandPurchaseOrder> GetById(int id)
        {
            GetPurchaseOrderDetailQuery command = new();
            command.Id = id;
            return await mediator.Send(command);
        }

        public async Task<List<CommandPurchaseOrder>> GetAll(int MWOId)
        {
            GetPurchaseOrdersListQuery command = new() { MWOId = MWOId };

            return await mediator.Send(command);
        }

        public async Task<ExportBaseResponse> GetFiletoExport(string type, List<CommandPurchaseOrder> List)
        {
            ExportPurchaseOrdersQuery export = new();
            export.Type = type;
            export.List = List;
            return await mediator.Send(export);

        }

        public async Task<PurchaseOrderDialogData> GetPurchaseOrderDataDialog(CommandPurchaseOrder Model)
        {
            PurchaseOrderDialogData data = new();

            data.ButtonName = GetButtonName(Model);
            data.DisableButtonSave = DisableButtonSave(Model);

            if(Model.PurchaseOrderStatus== PurchaseOrderApprovalStatus.Ordering)
            {
                Model.POEstimatedDate = DateTime.UtcNow;
            }

            Model.USDCOP = Model.Id == 0 ? _CurrencyService.RateList == null ? 4900 : Math.Round(_CurrencyService.RateList["COP"], 2) : Model.USDCOP;
            Model.USDEUR = Model.Id == 0 ? _CurrencyService.RateList == null ? 1 : Math.Round(_CurrencyService.RateList["EUR"], 2) : Model.USDEUR;

            data.InlineEdit = Model.Id == 0;
            GetMWOItemsListQuery mwoitems = new() { MWOId = Model.MWO.Id };
            data.MWOItemsOriginal = await mediator.Send(mwoitems);

            GetBrandsListQuery brands = new();
            data.Brands = await mediator.Send(brands);
            if (Model.pBrand.Id != 0)
            {
                data.Suppliers = await GetSupplierByBrand(Model.pBrand.Id);
            }

            return data;
        }

        public async Task<List<CommandSupplier>> GetSupplierByBrand(int brandId)
        {
            GetSuppliersListQuery supplieres = new() { BrandId = brandId };
            return await mediator.Send(supplieres);
        }
        string GetButtonName(CommandPurchaseOrder Model)
        {
            return Model.Id == 0 ? "Create PR" : Model.PurchaseOrderStatus == PurchaseOrderApprovalStatus.Ordering ? "Create PO" :
            Model.PurchaseOrderStatus == PurchaseOrderApprovalStatus.Created ?
            Model.pBrand.BrandType == BrandType.Brand ? "Receive PO" : "Install PO" :
            Model.PurchaseOrderStatus == PurchaseOrderApprovalStatus.Received ? "Install PO" : "Close";
        }
       public bool DisableButtonSave(CommandPurchaseOrder Model)
        {
            if (Model.Id == 0 && Model.PurchaseOrderItems.Count == 0) return true;

            if (Model.PurchaseOrderStatus == PurchaseOrderApprovalStatus.Received) return true;

            return false;
        }

        public CommandPurchaseOrderItem GetDataForAddItem(CommandMWOItem MWOItem, CommandPurchaseOrder Model)
        {

            Model.TaxCode = Model.TaxCode == "" ?
                MWOItem.ChapterId == 1 ?
                Model.pSupplier!.TaxCodeLP!.Name : Model.pSupplier!.TaxCodeLD!.Name : Model.TaxCode;
            Model.SPL = Model.SPL == "" ? MWOItem.ChapterId == 1 ? "0735015000" : "151605000" : Model.SPL;
            Model.CostCenter = MWOItem!.ChapterId! == 1 ? MWOItem!.AlterationItem!.CostCenter! : "";
            CommandPurchaseOrderItem purchaseOrderItem = new();
            purchaseOrderItem.MWOItem = MWOItem;
            purchaseOrderItem.PurchaseOrder = Model;
            return purchaseOrderItem;
        }
        public void AddPurchaseOrderItemToMWOItem(CommandPurchaseOrder Model, CommandPurchaseOrderItem purchaseOrderItem, PurchaseOrderDialogData data)
        {
            Model.PurchaseOrderItems.Add(purchaseOrderItem);
            data.MWOItemsOriginal.Remove(purchaseOrderItem.MWOItem);
            Model.PurchaseOrderItems = Model.PurchaseOrderItems.OrderBy(x => x.MWOItem!.Nomenclatore).ToList();
        }
        public void RemovePurchaseOrderItemFromMWOItem(CommandPurchaseOrder Model, PurchaseOrderDialogData data, int mwoitemid)
        {

            var selected = Model.PurchaseOrderItems.FirstOrDefault(x => x.MWOItemId == mwoitemid);
            Model.PurchaseOrderItems.Remove(selected);
            data.MWOItemsOriginal.Add(selected.MWOItem);
            Model.PurchaseOrderItems = Model.PurchaseOrderItems.OrderBy(x => x.MWOItem!.Nomenclatore).ToList();

        }
    }
}