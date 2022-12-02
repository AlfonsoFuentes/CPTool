

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

        [Parameter]
        public bool ShowAdd { get; set; } = true;
        [Parameter]

        public bool DisableAdd { get; set; } = false;
        [Parameter]

        public bool DisableEdit { get; set; } = false;
        [Parameter]

        public bool ShowDelete { get; set; } = true;
        [Parameter]

        public bool ShowReport { get; set; } = true;
        [Parameter]

        public bool ShowEdit { get; set; } = true;

    }
}
