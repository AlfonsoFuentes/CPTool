using CPTool.ApplicationCQRS.Features.TaxCodeLPs.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.TaxCodeLPs.Queries.Export
{

    public class ExportTaxCodeLPsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public Func<CommandTaxCodeLP, bool>? Filter { get; set; }
        public Func<CommandTaxCodeLP, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandTaxCodeLP, object?>> Dictionary = new Dictionary<string, Func<CommandTaxCodeLP, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
