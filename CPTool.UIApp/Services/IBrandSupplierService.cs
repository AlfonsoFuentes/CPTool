﻿

using CPTool.ApplicationCQRS.Features.Brands.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Brands.Queries.Export;
using CPTool.ApplicationCQRS.Features.BrandSuppliers.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.ConnectionTypes.Queries.Export;
using CPTool.ApplicationCQRS.Features.Suppliers.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Suppliers.Queries.Export;
using CPTool.ApplicationCQRS.Features.TaxCodeLDs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.TaxCodeLPs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using CPTool.ApplicationCQRSFeatures.Brands.Commands.Delete;
using CPTool.ApplicationCQRSFeatures.Brands.Queries.GetDetail;
using CPTool.ApplicationCQRSFeatures.Brands.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.BrandSuppliers.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.ConnectionTypes.Queries.GetDetail;
using CPTool.ApplicationCQRSFeatures.Suppliers.Commands.Delete;
using CPTool.ApplicationCQRSFeatures.Suppliers.Queries.GetDetail;
using CPTool.ApplicationCQRSFeatures.Suppliers.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.TaxCodeLDs.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.TaxCodeLPs.Queries.GetList;
using CPTool.Domain.Entities;
using MediatR;
using System.Runtime.InteropServices;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace CPTool.UIApp.Services
{
    public class SupplierDialogData
    {
        public List<CommandTaxCodeLD> TaxCodeLDs { get; set; } = new();
        public List<CommandTaxCodeLP> TaxCodeLPs { get; set; } = new();
        public List<CommandBrand> Brands { get; set; } = new();
    }
    public interface IBrandSupplierService
    {
        Task<DeleteBrandCommandResponse> DeleteBrand(int id);
        Task<DeleteSupplierCommandResponse> DeleteSupplier(int id);
        Task<BrandCommandResponse> AddUpdateBrand(CommandBrandSupplier command);
        Task<SupplierCommandResponse> AddUpdateSupplier(CommandBrandSupplier command);
        Task<CommandBrand> GetByIdBrand(int id);
        Task<CommandSupplier> GetByIdSupplier(int id);
        Task<List<CommandBrand>> GetAllBrand();
        Task<List<CommandSupplier>> GetAllSupplier();
        Task<List<CommandBrandSupplier>> GetAllBrandSupplier();
        
        Task<ExportBaseResponse> GetFiletoExportBrand(string type);
        Task<ExportBaseResponse> GetFiletoExportSupplier(string type);
        Task<SupplierDialogData> GetSupplierDataDialog();
    }
    public class BrandSupplierService : IBrandSupplierService
    {
        protected readonly IMediator mediator;

        public BrandSupplierService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public Task<DeleteBrandCommandResponse> DeleteBrand(int id)
        {
            DeleteBrandCommand delete = new() { Id = id };
            return mediator.Send(delete);
        }

        public Task<DeleteSupplierCommandResponse> DeleteSupplier(int id)
        {
            DeleteSupplierCommand delete = new() { Id = id };
            return mediator.Send(delete);
        }

        public async Task<BrandCommandResponse> AddUpdateBrand(CommandBrandSupplier command)
        {
            var result = await mediator.Send(command.Brand);

            await mediator.Send(command);
            return result;
        }

        public async Task<SupplierCommandResponse> AddUpdateSupplier(CommandBrandSupplier command)
        {
            var result = await mediator.Send(command.Supplier);

            await mediator.Send(command);
            return result;
        }

        public async Task<CommandBrand> GetByIdBrand(int id)
        {
            GetBrandDetailQuery command = new() { Id = id };

            return await mediator.Send(command);
     
        }

        public async Task<CommandSupplier> GetByIdSupplier(int id)
        {
            GetSupplierDetailQuery command = new() { Id=id };
            return await mediator.Send(command);
        }

        public async  Task<List<CommandBrand>> GetAllBrand()
        {
            GetBrandsListQuery command = new();
        return await mediator.Send(command);
            

        }

        public async Task<List<CommandSupplier>> GetAllSupplier()
        {
            GetSuppliersListQuery command = new();
            return await mediator.Send(command);
          
        }

        public async Task<ExportBaseResponse> GetFiletoExportBrand(string type)
        {
            ExportBrandsQuery export = new();
            export.Type = type;
            return await mediator.Send(export);
        }

        public async Task<ExportBaseResponse> GetFiletoExportSupplier(string type)
        {
            ExportSuppliersQuery export = new();
            export.Type = type;
            return await mediator.Send(export);
        }

        public async Task<SupplierDialogData> GetSupplierDataDialog()
        {
            SupplierDialogData result = new();
            GetBrandsListQuery brands = new();
            GetTaxCodeLDsListQuery ld = new();
            GetTaxCodeLPsListQuery lp = new();
            result.Brands = await mediator.Send(brands);
            result.TaxCodeLPs = await mediator.Send(lp);
            result.TaxCodeLDs = await mediator.Send(ld);

            return result;
        }

       

        public async Task<List<CommandBrandSupplier>> GetAllBrandSupplier()
        {
            GetBrandSuppliersListQuery command = new();
            return await mediator.Send(command);
        }
    }
}