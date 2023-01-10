
using CPTool.ApplicationCQRS.Features.Chapters.Commands.CreateUpdate;


using CPTool.ApplicationCQRS.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.Chapterss.Queries.Export
{

    public class ExportChaptersQuery : IRequest<ExportBaseResponse>
    {
        public string Type { get; set; } = string.Empty;
        public List<CommandChapter> List { get; set; } = new();
        public Dictionary<string, Func<CommandChapter, object?>> Dictionary = new Dictionary<string, Func<CommandChapter, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
