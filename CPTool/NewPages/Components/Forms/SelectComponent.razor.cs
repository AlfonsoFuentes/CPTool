using Microsoft.AspNetCore.Components.Web;

namespace CPTool.NewPages.Components.Forms
{
    public partial class SelectComponent<T> where T : EditCommand, new()
    {

        [Parameter]
        public bool Disable { get; set; } = false;
        [Parameter]
        public T Value { get; set; }
        [Parameter]
        public EventCallback<T> ValueChanged { get; set; }
        [Parameter]
        public EventCallback<T> SelectionChanged { get; set; }

        public int ValueInt => Value == null ? 0 : Value.Id;
        [Parameter]
        public string RequiredError { get; set; }
        [Parameter]
        public string PropertyName { get; set; } = "";
        [Parameter]
        public bool Required { get; set; }
        [Parameter]
        public string Label { get; set; }
        [Parameter]
        [Category(CategoryTypes.FormComponent.Validation)]
        public object Validation { get; set; }

        [Parameter]
        [EditorRequired]
        public List<T> Elements { get; set; } = new();


        List<ItemName> elements => getElements();
        List<ItemName> getElements()
        {
            List<ItemName> retorno = new();
            if (PropertyName == "") PropertyName = "Name";

            foreach (var item in Elements)
            {
                ItemName re = new();
                re.Id=item.Id;
                re.Name = item.GetType().GetProperty(PropertyName).GetValue(item).ToString();
                retorno.Add(re);
            }

            return retorno;
        }
        async Task InternaSelectChanged(int id)
        {
            if (id != 0) Value = Elements.FirstOrDefault(x => x.Id == id);
            else Value = null;
            await ValueChanged.InvokeAsync(Value);
            await SelectionChanged.InvokeAsync(Value);

        }
        class ItemName
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}