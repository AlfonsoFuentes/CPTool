
using CPTool.ApplicationCQRS.Features.BrandSuppliers.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.BrandSuppliers.Queries.Export
{

    public class ExportBrandSuppliersQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public List<CommandBrandSupplier> List { get; set; } = new();
        public Dictionary<string, Func<CommandBrandSupplier, object?>> Dictionary = new Dictionary<string, Func<CommandBrandSupplier, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
