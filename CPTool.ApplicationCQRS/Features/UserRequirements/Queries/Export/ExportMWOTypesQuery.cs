using CPTool.ApplicationCQRS.Features.UserRequirements.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.UserRequirements.Queries.Export
{

    public class ExportUserRequirementsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public Func<CommandUserRequirement, bool>? Filter { get; set; }
        public Func<CommandUserRequirement, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandUserRequirement, object?>> Dictionary = new Dictionary<string, Func<CommandUserRequirement, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
