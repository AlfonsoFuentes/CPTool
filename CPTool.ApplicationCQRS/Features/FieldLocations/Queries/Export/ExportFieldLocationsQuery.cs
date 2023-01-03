using CPTool.ApplicationCQRS.Features.AlterationItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.FieldLocations.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.FieldLocations.Queries.Export
{

    public class ExportFieldLocationsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public List<CommandFieldLocation> List { get; set; } = new();
        public Dictionary<string, Func<CommandFieldLocation, object?>> Dictionary = new Dictionary<string, Func<CommandFieldLocation, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
