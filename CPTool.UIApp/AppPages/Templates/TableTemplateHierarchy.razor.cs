using BlazorDownloadFile;
using CPTool.Application.Generic;
using CPTool.Persistence.BaseClass;
using Microsoft.AspNetCore.Components;
using Radzen.Blazor;
using Radzen;
using CPTool.ApplicationCQRS.Responses;

namespace CPTool.UIApp.AppPages.Templates
{
    public partial class TableTemplateHierarchy<T>:TableTemplate<T> where T : CommandBase, new()

    {
        
        [Parameter]
        public RenderFragment<T> Template { get; set; }
        
    }
}
