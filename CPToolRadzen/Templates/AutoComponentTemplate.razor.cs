using CPTool.Application.Generic;
using CPTool.Persistence.BaseClass;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Linq.Expressions;

namespace CPToolRadzen.Templates
{
    public partial class AutoComponentTemplate<T>
        where T : EditCommand, new()
    {
        [Inject]
        public ICommandQuery<T> CommandQuery { get; set; }
        [Parameter]
        [EditorRequired]
        public string PropertyName { get; set; } = string.Empty;
        [Parameter]
        [EditorRequired]
        public string Label { get; set; }


        [Parameter]
        public List<string> StringsToCompare { get; set; }
        public bool Any => StringsToCompare == null ? false : true;
        [Parameter]
        public bool Required { get; set; } = false;

        string RequiredText => $"{Label} is required";

        string ExistText => $"{Value} is existing";
        [Parameter]
        public List<T> Elements { get; set; }
        [Parameter]
        public EventCallback<List<T>> ElementsChanged { get; set; }

        [Parameter]
        public T Model { get; set; }
        [Parameter]
        public EventCallback<T> ModelChanged { get; set; }

        protected override void OnInitialized()
        {
            if (Model == null) return;
            Value = Model.GetType().GetProperty(PropertyName).GetValue(Model).ToString();
            if (Filter != null) Elements = Elements.Where(Filter).ToList();
            base.OnInitialized();
        }
        string Value { get; set; } = string.Empty;
       
        [Parameter]
        public EventCallback Change { get; set; }
        async Task OnChange(object value)
        {
            Value = value.ToString();

            var any = Elements.Any(x => x.GetType().GetProperty(PropertyName).GetValue(x).ToString().ToLower() == Value.ToLower());
            if (any)
            {
                Model = Elements.FirstOrDefault(x => x.GetType().GetProperty(PropertyName).GetValue(x).ToString().ToLower() == Value.ToLower());
                await ModelChanged.InvokeAsync(Model);
                if (Change.HasDelegate) await Change.InvokeAsync();
            }

        }
        async Task OnKeyDow(KeyboardEventArgs e)
        {
            if (e.Key == "Backspace")
            {
                Value = "";
                Model = new();
                await ModelChanged.InvokeAsync(Model);
                if (Change.HasDelegate) await Change.InvokeAsync();
                return;
            }

            if (e.Key != "Enter")
            {
                return;
            }

            var any = Elements.Any(x => x.GetType().GetProperty(PropertyName).GetValue(x).ToString().ToLower() == Value.ToLower());
            if (!any)
            {

                if (await DialogService.Confirm($"Do you want to add {Value} is in the list {Label} ?") == true)
                {
                    T model = new();
                    model.GetType().GetProperty(PropertyName).SetValue(model, Value);


                    var result = ShowDialog != null ? await ShowDialog(model) : (await CommandQuery.AddUpdate(model)).Succeeded;

                    if (result)
                    {
                        await UpdateComponent(model);
                    }

                }
            }
        }

        async Task UpdateComponent(T model)
        {
            Elements = await CommandQuery.GetAll();
            await ElementsChanged.InvokeAsync(Elements);
            Model = model;
            await ModelChanged.InvokeAsync(model);
            if (Change.HasDelegate) await Change.InvokeAsync();
            if (Filter != null) {

                Func<T, bool> filter = x => x.Id == 1;
                Elements = Elements.Where(Filter).ToList(); 
            
            }
        }

        [Parameter]
        public Func<T, Task<bool>> ShowDialog { get; set; }
        [Parameter]
        public bool Disabled { get; set; } = false;



        [Parameter]
        public Func<T, bool> Filter { get; set; }
    }
}
