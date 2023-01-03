using CPTool.ApplicationCQRS.Features.MWOTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.UserRequirementTypes.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.UserRequirementTypes.Queries.Export
{

    public class ExportUserRequirementTypesQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public List<CommandUserRequirementType> List { get; set; } = new();
        public Dictionary<string, Func<CommandUserRequirementType, object?>> Dictionary = new Dictionary<string, Func<CommandUserRequirementType, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
