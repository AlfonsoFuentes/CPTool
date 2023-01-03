using CPTool.ApplicationCQRS.Features.MWOTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Units.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.Units.Queries.Export
{

    public class ExportUnitsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public List<CommandUnit> List { get; set; } = new();
        public Dictionary<string, Func<CommandUnit, object?>> Dictionary = new Dictionary<string, Func<CommandUnit, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name},
                     { "Unit Name",item => item.UnitName},
                     { "Value",item => item.StringValue},
                };
    }
}
