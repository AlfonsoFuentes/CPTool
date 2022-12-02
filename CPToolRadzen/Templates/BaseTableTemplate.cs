using CPTool.ApplicationRadzen.FeaturesGeneric;
using CPTool.Persistence.BaseClass;
using Microsoft.AspNetCore.Components;

namespace CPToolRadzen.Templates
{
    public class BaseTableTemplate<T>: ComponentBase where T:EditCommand ,new()
    {
        [Inject]
        public ICommandQuery<T> CommandQuery { get; set; }
        [Parameter]
        public int ParentId { get; set; }

       
        public virtual List<T> Elements { get; set; }

       
        public T Selected { get; set; } = new();

        [Parameter]
        [EditorRequired]
        public string TableName { get; set; }
        public bool DisableEdit => Selected.Id == 0;
        protected  virtual void OnInitializedBase()
        {
            base.OnInitialized();
        }

    }
}
