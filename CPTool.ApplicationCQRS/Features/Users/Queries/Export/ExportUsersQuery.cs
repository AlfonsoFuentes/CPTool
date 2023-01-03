using CPTool.ApplicationCQRS.Features.MWOTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Users.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.Users.Queries.Export
{

    public class ExportUsersQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public List<CommandUser> List { get; set; } = new();
        public Dictionary<string, Func<CommandUser, object?>> Dictionary = new Dictionary<string, Func<CommandUser, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
