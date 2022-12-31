using CPTool.ApplicationCQRS.Features.ProcessConditions.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.ProcessConditions.Queries.Export
{

    public class ExportProcessConditionsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public Func<CommandProcessCondition, bool>? Filter { get; set; }
        public Func<CommandProcessCondition, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandProcessCondition, object?>> Dictionary = new Dictionary<string, Func<CommandProcessCondition, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
