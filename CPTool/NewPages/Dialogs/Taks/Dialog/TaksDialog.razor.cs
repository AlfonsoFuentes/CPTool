﻿using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;
using CPTool.Application.Features.TaksFeatures.CreateEdit;

namespace CPTool.NewPages.Dialogs.Taks.Dialog
{
    public partial class TaksDialog
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = null!;
        [Parameter]
        public EditTaks Model { get; set; } = null!;



        [Inject]
        public IMediator mediator { get; set; }

        [Parameter]
        public MudForm form { get; set; } = null!;

        async Task ValidateForm()
        {
            await form.Validate();
        }

        public async virtual Task Submit()
        {
            await ValidateForm();
            if (form.IsValid)
            {
                if (Model.TaksType == Domain.Entities.TaksType.Manual)
                {
                    if (Model.TaksStatus == Domain.Entities.TaksStatus.Draft)
                    {
                        Model.TaksStatus = Domain.Entities.TaksStatus.Pending;

                    }
                    else if (Model.TaksStatus == Domain.Entities.TaksStatus.Pending)
                    {
                        Model.TaksStatus = Domain.Entities.TaksStatus.Completed;
                        Model.CompletionDate = DateTime.Now;
                    }
                }

                await mediator.Send(Model);

                MudDialog.Close(DialogResult.Ok(Model));
            }
        }

        void Cancel() => MudDialog.Cancel();
    }
}