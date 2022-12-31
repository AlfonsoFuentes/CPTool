using CPTool.ApplicationCQRS.Features.DownPayments.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.DownPayments.Queries.Export
{

    public class ExportDownPaymentsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public Func<CommandDownPayment, bool>? Filter { get; set; }
        public Func<CommandDownPayment, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandDownPayment, object?>> Dictionary = new Dictionary<string, Func<CommandDownPayment, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
