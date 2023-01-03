using CPTool.ApplicationCQRS.Features.AlterationItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.MWOs.Queries.Export
{

    public class ExportMWOsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public List<CommandMWO> List { get; set; } = new();
        public Dictionary<string, Func<CommandMWO, object?>> Dictionary = new Dictionary<string, Func<CommandMWO, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    
                    { "Type",item => item.MWOTypeName} ,
                    { "Name",item => item.Name},
                    { "Project Leader",item => item.ProjectLeader}
            ,       { "CEB#",item => item.CEBName}
            ,
                    { "CEC#",item => item.CECName},
                    { "Approval date",item => item.ApprovalDate.ToShortDateString()}
            
                   
            ,
                    { "Budget, USD",item => item.Budget}
            ,
                    { "Expenses, USD",item => item.Expenses}
            ,
                    { "Assigned, USD",item => item.Assigned}
              ,
                    { "Actual,USD",item => item.Actual}
            ,
                    { "Commitment, USD",item => item.Commitment}
            ,
                    { "Pending, USD",item => item.Pending}
            ,
                    { "Actual Expenses, $COP",item => item.ActualExpenses}
            ,
                    { "Commitment Expenses, $COP",item => item.CommitmentExpenses}
            ,
                    { "Pending Expenses, $COP",item => item.PendingExpenses}
             
                };
    }
}
