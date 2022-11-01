﻿using Microsoft.AspNetCore.Components;
using MudBlazor;
using CPTool.Application.Features.Base;
using MediatR;

using CPTool.Application.Features.Base.DeleteCommand;


namespace CPTool2.NewPages.Components
{
    public partial class TableNameDialog<T> where T : EditCommand, new()
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = null!;
        public MudForm form { get; set; } = null!;
        [Parameter]
        public T Model { get; set; }
        public async virtual Task Submit()
        {
            await form.Validate();
            if (form.IsValid)
            {

                MudDialog.Close(DialogResult.Ok(Model));
            }
        }

        void Cancel() => MudDialog.Cancel();

    }
}