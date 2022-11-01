



using CPTool.Application.Features.Base;

namespace CPTool.NewPages.Components
{
    public partial class TableComponent<T> where T : EditCommand, new()
    {

        [Parameter]
        [EditorRequired]
        public List<T> Elements { get; set; } = new();
        [Parameter]
        public RenderFragment ContextTh { get; set; }
        [Parameter]
        public RenderFragment<T> ContextTd { get; set; }

        [Parameter]
        public T SelectedItem { get; set; } = new();
        [Parameter]
        public EventCallback<T> SelectedItemChanged { get; set; }

        [Parameter]
        public EventCallback<TableRowClickEventArgs<T>> OnRowClicked { get; set; }

        [Parameter]
        public RenderFragment OtherButtons { get; set; }
        private bool FilterFunc1(T element) => FilterFunc(element, searchString1);

        [Parameter]
        [EditorRequired]
        public Func<T, string, bool> SearchFunc { get; set; }

        string SelectedItemName=>SelectedItem==null? string.Empty:SelectedItem.Name;
        private bool FilterFunc(T element, string searchString)
        {
            var retorno = SearchFunc.Invoke(element, searchString);///* SearchFunc == null ?*/ element.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) /*: SearchFunc.Invoke(element, searchString)*/;
            return retorno;


        }
       
       
        [Parameter]
        public EventCallback OnAdd { get; set; }

        [Parameter]
        public EventCallback OnEdit { get; set; }

        [Parameter]
        public EventCallback OnDelete { get; set; }

       
    }
}
