using CPTool.ApplicationCQRS.Features.AlterationItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.DeviceFunctionModifiers.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.DeviceFunctionModifiers.Queries.Export
{

    public class ExportDeviceFunctionModifiersQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public List<CommandDeviceFunctionModifier> List { get; set; } = new();
        public Dictionary<string, Func<CommandDeviceFunctionModifier, object?>> Dictionary = new Dictionary<string, Func<CommandDeviceFunctionModifier, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
