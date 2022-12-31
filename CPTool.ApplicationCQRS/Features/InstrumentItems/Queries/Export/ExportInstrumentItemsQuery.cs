using CPTool.ApplicationCQRS.Features.InstrumentItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.InstrumentItems.Queries.Export
{

    public class ExportInstrumentItemsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public Func<CommandInstrumentItem, bool>? Filter { get; set; }
        public Func<CommandInstrumentItem, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandInstrumentItem, object?>> Dictionary = new Dictionary<string, Func<CommandInstrumentItem, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
