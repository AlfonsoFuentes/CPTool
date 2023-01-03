using CPTool.ApplicationCQRS.Features.Suppliers.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.Suppliers.Queries.Export
{

    public class ExportSuppliersQuery : IRequest<ExportBaseResponse>
    {
        public List<CommandSupplier> List { get; set; } = new();
        public string Type { get; set; } = string.Empty;
       
        public Dictionary<string, Func<CommandSupplier, object?>> Dictionary = new Dictionary<string, Func<CommandSupplier, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name},
                     { "Vendor Code",item => item.VendorCode},
                     { "Tax Code LD",item => item.TaxCodeLDName},
                     { "Tax Code LP",item => item.TaxCodeLPName},
                      { "ContactPerson",item => item.ContactPerson},
                       { "Email",item => item.Email},
                        { "Phone",item => item.Phone},

                };
    }
}
