



using CPTool.Interfaces;

namespace CPTool.Pages.Components
{
    public partial class ComponentToolbar<T> where T: AuditableEntityDTO,new()
    {
        [Parameter]
        public T SelectedItem { get; set; }=new();

        [Parameter]
        public RenderFragment OtherButtons { get; set; }

        [Parameter]
        public EventCallback OnAdd { get; set; }
        [Parameter]
        public EventCallback<T> OnEdit { get; set; }
        [Parameter]
        public EventCallback<T> OnDelete { get; set; }
        [Parameter]
        public EventCallback<T> OnPrint { get; set; }
        [Parameter]
        public EventCallback<T> OnExcel { get; set; }
        [Parameter]
        public EventCallback<T> OnPDF { get; set; }


        async Task Add()
        {
            await OnAdd.InvokeAsync();
        }
        async Task Edit()
        {
            await OnEdit.InvokeAsync(SelectedItem);
        }
        async Task Delete()
        {
            await OnDelete.InvokeAsync(SelectedItem);
        }
        async Task Print()
        {
            await OnPrint.InvokeAsync(SelectedItem);
        }
        async Task Excel()
        {
            await OnExcel.InvokeAsync(SelectedItem);
        }
        async Task PDF()
        {
            await OnPDF.InvokeAsync(SelectedItem);
        }
    }
}
