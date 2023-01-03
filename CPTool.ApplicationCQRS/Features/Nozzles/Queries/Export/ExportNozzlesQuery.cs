using CPTool.ApplicationCQRS.Features.MWOTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Nozzles.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.Nozzles.Queries.Export
{

    public class ExportNozzlesQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public List<CommandNozzle> List { get; set; } = new();
        public Dictionary<string, Func<CommandNozzle, object?>> Dictionary = new Dictionary<string, Func<CommandNozzle, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.NameDescription},
                     { "Name",item => item.StreamTypeName},
                      { "Name",item => item.PipeClassName},
                    { "Name",item => item.PipeDiameterName},
                    { "Name",item => item.ConnectionTypeName},
                       { "Name",item => item.MaterialName},
                    { "Name",item => item.GasketName},
                 
                   
                    

                };
    }
}
