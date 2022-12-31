using CPTool.ApplicationCQRS.Features.MeasuredVariables.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.MeasuredVariables.Queries.Export
{

    public class ExportMeasuredVariablesQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public Func<CommandMeasuredVariable, bool>? Filter { get; set; }
        public Func<CommandMeasuredVariable, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandMeasuredVariable, object?>> Dictionary = new Dictionary<string, Func<CommandMeasuredVariable, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
