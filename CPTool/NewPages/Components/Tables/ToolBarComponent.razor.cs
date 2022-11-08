

using CPTool.Application.Features.Base;

namespace CPTool.NewPages.Components.Tables
{
    public partial class ToolBarComponent
    {
       
        [Parameter]
        public RenderFragment OtherButtons { get; set; } = null!;
        [Parameter]
        public EventCallback OnAdd { get; set; }
        [Parameter]
        public EventCallback OnEdit { get; set; }
        [Parameter]
        public EventCallback OnDelete { get; set; }
        [Parameter]
        public EventCallback OnPrint { get; set; }
        [Parameter]
        public EventCallback OnExcel { get; set; }
        [Parameter]
        public EventCallback OnPDF { get; set; }


       
    }
}
