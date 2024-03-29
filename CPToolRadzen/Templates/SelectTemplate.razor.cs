﻿using CPTool.Persistence.BaseClass;
using Microsoft.AspNetCore.Components;

namespace CPToolRadzen.Templates
{
    public partial class SelectTemplate<T>
        where T : EditCommand, new()
    {
        [Parameter]
        [EditorRequired]
        public string PropertyName { get; set; } = string.Empty;
        [Parameter]
        public Func<T, bool> Filter { get; set; }
        [Parameter]
        public List<T> Elements { get; set; }
        [Parameter]
        public T Model { get; set; }

        public T LocalModel { get; set; }
        [Parameter]
        public EventCallback<T> ModelChanged { get; set; }

        [Parameter]
        public bool Required { get; set; } = false;
        [Parameter]
        public bool Disabled { get; set; } = false;
        [Parameter]
        public bool Clearable { get; set; } = false;

        string RequiredText => $"{Label} is required";
        [Parameter]
        [EditorRequired]
        public string Label { get; set; }
        protected override void OnInitialized()
        {
            LocalModel = Model == null ? new() : Model;
            base.OnInitialized();
        }
        async Task OnChange()
        {
            Model = LocalModel == null ? new() : LocalModel;
            await ModelChanged.InvokeAsync(Model);
            if (Change.HasDelegate) await Change.InvokeAsync();

        }
        [Parameter]
        public EventCallback Change { get; set; }
        public List<T> ElementsLocal => Filter == null ? Elements : Elements.Where(Filter).ToList();
    }
}
