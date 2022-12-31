﻿using CPTool.ApplicationCQRS.Features.ProcessFluids.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.ProcessFluids.Queries.Export
{

    public class ExportProcessFluidsQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public Func<CommandProcessFluid, bool>? Filter { get; set; }
        public Func<CommandProcessFluid, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandProcessFluid, object?>> Dictionary = new Dictionary<string, Func<CommandProcessFluid, object?>>()
                {

                    {"Id",item => item.Id},
                    { "Name",item => item.Name},
             { "Abbreviation",item => item.TagLetter},
               { "Property Package",item => item.PropertyPackage==null?"":item.PropertyPackage.Name}
                };
    }
}
