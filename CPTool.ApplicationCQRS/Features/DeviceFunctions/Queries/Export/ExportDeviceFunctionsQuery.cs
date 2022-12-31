using CPTool.ApplicationCQRS.Features.DeviceFunctions.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.DeviceFunctions.Queries.Export
{

    public class ExportDeviceFunctionsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public Func<CommandDeviceFunction, bool>? Filter { get; set; }
        public Func<CommandDeviceFunction, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandDeviceFunction, object?>> Dictionary = new Dictionary<string, Func<CommandDeviceFunction, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
