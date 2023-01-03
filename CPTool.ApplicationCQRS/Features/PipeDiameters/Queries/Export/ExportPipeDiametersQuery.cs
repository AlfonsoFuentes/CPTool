using CPTool.ApplicationCQRS.Features.MWOTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PipeDiameters.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.PipeDiameters.Queries.Export
{

    public class ExportPipeDiametersQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public List<CommandPipeDiameter> List { get; set; } = new();
        public Dictionary<string, Func<CommandPipeDiameter, object?>> Dictionary = new Dictionary<string, Func<CommandPipeDiameter, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "DN",item => item.Name},
                    { "OD",item => item.OuterDiameter.StringValue},
                    { "ID",item => item.InternalDiameter.StringValue},
                    { "Thicknes",item => item.Thickness.StringValue}

                };
    }
}
