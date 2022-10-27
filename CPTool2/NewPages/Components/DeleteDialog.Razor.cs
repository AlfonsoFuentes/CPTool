﻿

using CPTool.Application.Features.Base.DeleteCommand;
using MediatR;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CPTool2.NewPages.Components
{
    public partial class DeleteDialog
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = null!;
        [Parameter]
        public Delete Model { get; set; } = null!;

        [Parameter]
        public string Message { get; set; } = null!;
        [Inject]
        public IMediator mediator { get; set; }

        public async  Task Submit()
        {
            
            var result = await mediator.Send(Model);

            MudDialog.Close(DialogResult.Ok(true));
        }

        void Cancel() => MudDialog.Cancel();
    }
}
