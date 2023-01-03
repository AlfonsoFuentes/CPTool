using CPTool.ApplicationCQRS.Features.MWOTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Takss.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.Takss.Queries.Export
{

    public class ExportTakssQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public List<CommandTaks> List { get; set; } = new();
        public Dictionary<string, Func<CommandTaks, object?>> Dictionary = new Dictionary<string, Func<CommandTaks, object?>>()
                {
                  
                    {"Id",item => item.Id}
             ,
                    { "CEC#",item => item.CECName}
              ,
                    { "MWO Name",item => item.MWOName}
            ,
                    { "Type",item => item.TaksTypeName}
            ,
                    { "Status",item => item.TaksStatusName}
            ,
                    { "Description",item => item.Name}
        
            
           

                };
    }
}
