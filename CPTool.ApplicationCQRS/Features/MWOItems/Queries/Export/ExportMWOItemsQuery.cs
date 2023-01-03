using CPTool.ApplicationCQRS.Features.AlterationItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.MWOItems.Queries.Export
{

    public class ExportMWOItemsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public List<CommandMWOItem> List { get; set; } = new();
        public Dictionary<string, Func<CommandMWOItem, object?>> Dictionary = new Dictionary<string, Func<CommandMWOItem, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Chapter",item => item.ChapterName},
                    { "Nomenclatore",item => item.Nomenclatore},
                    { "TagId",item => item.TagId},
                    { "Name",item => item.Name},
                    { "Existing?",item => item.Existing}
            ,
                    { "Unitary Prize Name",item => item.UnitaryBasePrizeName}
            ,
                    { "Budget",item => item.BudgetPrize},
                    { "Assigned, USD",item => item.Assigned},
                    { "Actual, USD",item => item.Actual},
                    { "Commitment, USD",item => item.Commitment} ,
                    { "Pending, USD",item => item.Pending}


                };
    }
}
