
using CPTool.ApplicationCQRS.Features.ElectricalBoxs.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.ElectricalBoxs.Queries.Export
{

    public class ExportElectricalBoxsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public List<CommandElectricalBox> List { get; set; } = new();
        public Dictionary<string, Func<CommandElectricalBox, object?>> Dictionary = new Dictionary<string, Func<CommandElectricalBox, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
