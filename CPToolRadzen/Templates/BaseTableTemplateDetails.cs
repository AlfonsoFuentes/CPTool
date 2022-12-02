using CPTool.ApplicationRadzen.FeaturesGeneric;
using CPTool.Persistence.BaseClass;
using Microsoft.AspNetCore.Components;

namespace CPToolRadzen.Templates
{
    public class BaseTableTemplateDetails<T,TDetails> : ComponentBase 
        where T : EditCommand, new()
         where TDetails : EditCommand, new()
    {
        [Inject]
        public ICommandQuery<T> CommandQuery { get; set; }
        [Inject]
        public ICommandQuery<TDetails> CommandQueryDetails { get; set; }

        [Parameter]
        public List<T> Elements { get; set; }
        [Parameter]
        public List<TDetails> ElementsDetails { get; set; }

        public T Selected { get; set; } = new();
        public TDetails SelectedDetail { get; set; } = new();

        public bool DisableEdit => Selected.Id == 0;
        public bool DisableEditDetail => SelectedDetail.Id == 0;
        protected virtual void OnInitializedBase()
        {
            base.OnInitialized();
        }
    }
}
