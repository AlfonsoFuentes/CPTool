using CPTool.ApplicationCQRS.Features.Brands.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.Brands.Queries.Export
{

    public class ExportBrandsQuery : IRequest<ExportBaseResponse>
    {
        public List<CommandBrand> List = new List<CommandBrand>();
        public string Type { get; set; } = string.Empty;
       
        public Dictionary<string, Func<CommandBrand, object?>> Dictionary = new Dictionary<string, Func<CommandBrand, object?>>()
                {

                    {"Id",item => item.Id},
                    { "Name",item => item.Name},
             { "Type",item => item.BrandTypeName}
                };
    }
}
