
using CPTool.ApplicationCQRS.Features.MeasuredVariableModifiers.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.MeasuredVariableModifiers.Queries.Export
{

    public class ExportMeasuredVariableModifiersQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public List<CommandMeasuredVariableModifier> List { get; set; } = new();
        public Dictionary<string, Func<CommandMeasuredVariableModifier, object?>> Dictionary = new Dictionary<string, Func<CommandMeasuredVariableModifier, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
