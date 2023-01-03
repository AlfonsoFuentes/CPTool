using CPTool.ApplicationCQRS.Features.MWOTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Signals.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.Signals.Queries.Export
{

    public class ExportSignalsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public List<CommandSignal> List { get; set; } = new();
        public Dictionary<string, Func<CommandSignal, object?>> Dictionary = new Dictionary<string, Func<CommandSignal, object?>>()
                {
                  
                    {"Id",item => item.Id},

                    { "Signal Name",item => item.Name},

                    { "MWO Name",item => item.MWOName},


                    { "Item Tag Id",item => item.MWOItemTagId}
            ,
                    { "Signal Type",item => item.SignalTypeName}
            ,
                    { "I/O Type",item => item.IOTypeName}
            ,
                    { "Wire Name",item => item.WireName}
            ,
                    { "Location",item => item.FieldLocationName}
            ,
                    { "Electrical Box Name",item => item.ElectricalBoxName}
            ,
                    { "Has Frequency Inverte?",item => item.FrequencyInverter}
            ,
                    { "Has instrument air?",item => item.InstrumentAir}
            ,
                    { "Has Disconnect?",item => item.Disconect}
            ,
                    { "Is Wired?",item => item.IsWired}

                };
    }
}
