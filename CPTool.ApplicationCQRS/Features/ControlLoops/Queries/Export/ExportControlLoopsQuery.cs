
using CPTool.ApplicationCQRS.Features.ControlLoops.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.ControlLoops.Queries.Export
{

    public class ExportControlLoopsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public List<CommandControlLoop> List { get; set; } = new();
        public Dictionary<string, Func<CommandControlLoop, object?>> Dictionary = new Dictionary<string, Func<CommandControlLoop, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Control Type",item => item.ControlLoopTypeName}
            ,
                    { "Process Variable",item => item.ProcessVariableName}
            ,
                    { "Controlled Variable",item => item.ControlledVariableName}
            ,
                    { "Proportional Gain",item => item.PTerm}
            ,
                    { "Integral Gain 1/s",item => item.ITerm}
            ,
                    { "Derivative Gain, s",item => item.DTerm}
            ,
                    { "Action",item => item.ActionTypeName}
            ,
                    { "Fail",item => item.FailTypeName}
            ,
                    { "Alarm Text",item => item.AlarmText}
            ,
                    { "CV Min,%",item => item.ControlledVariableMin}
            ,
                    { "CV Max, %",item => item.ControlledVariableMax}
           

                };
    }
}
