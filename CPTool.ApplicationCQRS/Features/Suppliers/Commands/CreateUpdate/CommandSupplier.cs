using CPtool.ExtensionMethods;
using CPTool.ApplicationCQRS.Features.BrandSuppliers.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.TaxCodeLDs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.TaxCodeLPs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.Suppliers.Commands.CreateUpdate
{
    public class CommandSupplier : CommandBase, IRequest<SupplierCommandResponse>
    {

        public int SupplierOriginalId { get; set; }
        public List<CommandBrandSupplier>? BrandSuppliers { get; set; } = new();
      
        public string Address { get; set; } = "";
      
        public string Phone { get; set; } = "";

     
        public string Email { get; set; } = "";
      
        public string ContactPerson { get; set; } = "";


        public int? TaxCodeLPId => TaxCodeLP?.Id == 0 ? null : TaxCodeLP?.Id;
        public CommandTaxCodeLP? TaxCodeLP { get; set; }
      
        public string TaxCodeLPName => TaxCodeLP == null ? "" : TaxCodeLP!.Name;
       
        public string? VendorCode { get; set; } = "";
        public int? TaxCodeLDId => TaxCodeLD?.Id == 0 ? null : TaxCodeLD?.Id;
        public CommandTaxCodeLD? TaxCodeLD { get; set; }
       
        public string TaxCodeLDName => TaxCodeLD == null ? "" : TaxCodeLD!.Name;


    }

}
