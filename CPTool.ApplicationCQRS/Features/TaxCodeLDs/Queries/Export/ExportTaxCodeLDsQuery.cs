using CPTool.ApplicationCQRS.Features.MWOTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.TaxCodeLDs.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.TaxCodeLDs.Queries.Export
{

    public class ExportTaxCodeLDsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public List<CommandTaxCodeLD> List { get; set; } = new();
        public Dictionary<string, Func<CommandTaxCodeLD, object?>> Dictionary = new Dictionary<string, Func<CommandTaxCodeLD, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
