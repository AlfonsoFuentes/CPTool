using CPTool.ApplicationCQRS.Features.TaxesItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.TaxesItems.Queries.Export
{

    public class ExportTaxesItemsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public Func<CommandTaxesItem, bool>? Filter { get; set; }
        public Func<CommandTaxesItem, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandTaxesItem, object?>> Dictionary = new Dictionary<string, Func<CommandTaxesItem, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
