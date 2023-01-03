using CPTool.ApplicationCQRS.Features.MWOTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.UnitaryBasePrizes.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.UnitaryBasePrizes.Queries.Export
{

    public class ExportUnitaryBasePrizesQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public List<CommandUnitaryBasePrize> List { get; set; } = new();
        public Dictionary<string, Func<CommandUnitaryBasePrize, object?>> Dictionary = new Dictionary<string, Func<CommandUnitaryBasePrize, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
