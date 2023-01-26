

using CPTool.ApplicationCQRS.Features.Brands.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Brands.Queries.Export;
using CPTool.ApplicationCQRS.Features.BrandSuppliers.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.ConnectionTypes.Queries.Export;
using CPTool.ApplicationCQRS.Features.PurchaseOrders.Commands.CreateUpdate;
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
using Microsoft.IdentityModel.Tokens;
using System.Runtime.InteropServices;


namespace CPTool.InfrastructureCQRS.Services
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

        Task<ExportBaseResponse> GetFiletoExportBrand(string type, List<CommandBrand> toExport);
        Task<ExportBaseResponse> GetFiletoExportSupplier(string type, List<CommandSupplier> toExport);
        Task<SupplierDialogData> GetSupplierDataDialog();
        List<CommandBrand> SearchListBrand(List<CommandBrand> brands, string searched);
        List<CommandSupplier> SearchListSupplier(List<CommandSupplier> suppliers, string searched);
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
            var result = await mediator.Send(command.Brand!);
            command.Brand = result.ResponseObject;
            await mediator.Send(command);
            return result;
        }

        public async Task<SupplierCommandResponse> AddUpdateSupplier(CommandBrandSupplier command)
        {
            var result = await mediator.Send(command.Supplier);

            command.Supplier = result.ResponseObject;

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
            GetSupplierDetailQuery command = new() { Id = id };
            return await mediator.Send(command);
        }

        public async Task<List<CommandBrand>> GetAllBrand()
        {
            GetBrandsListQuery command = new();
            return await mediator.Send(command);


        }

        public async Task<List<CommandSupplier>> GetAllSupplier()
        {
            GetSuppliersListQuery command = new();
            return await mediator.Send(command);

        }

        public async Task<ExportBaseResponse> GetFiletoExportBrand(string type, List<CommandBrand> toExport)
        {
            ExportBrandsQuery export = new();
            export.List = toExport;
            export.Type = type;
            return await mediator.Send(export);
        }

        public async Task<ExportBaseResponse> GetFiletoExportSupplier(string type, List<CommandSupplier> toExport)
        {
            ExportSuppliersQuery export = new();
            export.List = toExport;
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
        public List<CommandBrand> SearchListBrand(List<CommandBrand> brands, string searched)
        {
            List<CommandBrand> result = new();
            if (searched.IsNullOrEmpty()) return brands;
            if (brands.Any(x => x.Name.ToLower().Contains(searched.ToLower())))
            {
                result.AddRange(brands.Where(x => x.Name.ToLower().Contains(searched.ToLower())));

            }
            if (brands.Any(x => x.BrandTypeName.ToLower().Contains(searched.ToLower())))
            {
                result.AddRange(brands.Where(x => x.BrandTypeName.ToLower().Contains(searched.ToLower()) && !result.Any(y => y.Id == x.Id)));

            }
            return result;
        }
        public List<CommandSupplier> SearchListSupplier(List<CommandSupplier> suppliers, string searched)
        {
            List<CommandSupplier> result = new();
            if (searched.IsNullOrEmpty()) return suppliers;
            if (suppliers.Any(x => x.Name.ToLower().Contains(searched.ToLower())))
            {
                result.AddRange(suppliers.Where(x => x.Name.ToLower().Contains(searched.ToLower())));

            }
            if (suppliers.Any(x => x.VendorCode!.ToLower().Contains(searched.ToLower())))
            {
                result.AddRange(suppliers.Where(x => x.VendorCode!.ToLower().Contains(searched.ToLower() )&& !result.Any(y => y.Id == x.Id)));

            }
            if (suppliers.Any(x => x.TaxCodeLDName.ToLower().Contains(searched.ToLower()) && !result.Any(y => y.Id == x.Id)))
            {
                result.AddRange(suppliers.Where(x => x.TaxCodeLDName.ToLower().Contains(searched.ToLower()) && !result.Any(y => y.Id == x.Id)));

            }
            if (suppliers.Any(x => x.TaxCodeLPName.ToLower().Contains(searched.ToLower())))
            {
                result.AddRange(suppliers.Where(x => x.TaxCodeLPName.ToLower().Contains(searched.ToLower()) && !result.Any(y => y.Id == x.Id)));

            }
            return result;
        }
    }
}