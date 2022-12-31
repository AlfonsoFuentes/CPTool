using CPTool.ApplicationCQRS.Features.PropertyPackages.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.PropertyPackages.Queries.Export
{

    public class ExportPropertyPackagesQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public Func<CommandPropertyPackage, bool>? Filter { get; set; }
        public Func<CommandPropertyPackage, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandPropertyPackage, object?>> Dictionary = new Dictionary<string, Func<CommandPropertyPackage, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
