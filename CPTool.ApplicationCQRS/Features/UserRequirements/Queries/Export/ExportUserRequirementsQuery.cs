using CPTool.ApplicationCQRS.Features.MWOTypes.Commands.CreateUpdate;
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
        public List<CommandUserRequirement> List { get; set; } = new();
        public Dictionary<string, Func<CommandUserRequirement, object?>> Dictionary = new Dictionary<string, Func<CommandUserRequirement, object?>>()
                {
                  
                    {"Id",item => item.Id},
                     { "MWO",item => item.MWOName},
                     { "Type",item => item.UserRequirementTypeName},
                    { "Name",item => item.Name},
                    { "Requested By:",item => item.RequestedByName},

                };
    }
}
