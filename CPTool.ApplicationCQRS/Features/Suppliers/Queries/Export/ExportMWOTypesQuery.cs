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
        public string Type { get; set; } = string.Empty;
        public Func<CommandSupplier, bool>? Filter { get; set; }
        public Func<CommandSupplier, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandSupplier, object?>> Dictionary = new Dictionary<string, Func<CommandSupplier, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
