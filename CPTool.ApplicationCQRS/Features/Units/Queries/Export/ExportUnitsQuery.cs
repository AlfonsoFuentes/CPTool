using CPTool.ApplicationCQRS.Features.Units.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.Units.Queries.Export
{

    public class ExportUnitsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public Func<CommandUnit, bool>? Filter { get; set; }
        public Func<CommandUnit, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandUnit, object?>> Dictionary = new Dictionary<string, Func<CommandUnit, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
