
using CPTool.ApplicationCQRS.Features.Materials.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.Materials.Queries.Export
{

    public class ExportMaterialsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public List<CommandMaterial> List { get; set; } = new();
        public Dictionary<string, Func<CommandMaterial, object?>> Dictionary = new Dictionary<string, Func<CommandMaterial, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
