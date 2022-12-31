using CPTool.ApplicationCQRS.Features.ElectricalItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.ElectricalItems.Queries.Export
{

    public class ExportElectricalItemsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public Func<CommandElectricalItem, bool>? Filter { get; set; }
        public Func<CommandElectricalItem, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandElectricalItem, object?>> Dictionary = new Dictionary<string, Func<CommandElectricalItem, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
