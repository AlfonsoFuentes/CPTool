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
        public Func<CommandChapter, bool>? Filter { get; set; }
        public Func<CommandChapter, bool>? OrderBy { get; set; }
        public Dictionary<string, Func<CommandChapter, object?>> Dictionary = new Dictionary<string, Func<CommandChapter, object?>>()
                {
                  
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                };
    }
}
