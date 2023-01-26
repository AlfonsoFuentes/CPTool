using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Nozzles.Commands.CreateUpdate;
using CPTool.ApplicationCQRSResponses;
using CPTool.Domain.Entities;
using CPTool.InfrastructureCQRS.Services;
using CPTool.UIApp.AppPages.Nozzles;
using Microsoft.AspNetCore.Components;
using Radzen;
using System.Runtime.InteropServices;

namespace CPTool.UIApp.AppPages.MWOItemsNew
{
    public partial class MWOItemDialogNew
    {

        [Inject]
        IMWOService MWOService { get; set; }
        [Inject]
        public IMWOItemService Service { get; set; }

        public CommandMWOItem Model { get; set; } = new();
        [Parameter]
        public int MWOId { get; set; }
        [Parameter]
        public int MWOItemId { get; set; } = 0;
        [Parameter]
        public bool Budget { get; set; } = false;
        bool loaded = false;
        protected override async Task OnInitializedAsync()
        {


            if (MWOItemId == 0)
            {
                Model = new();
                Model.MWO = await MWOService.GetById(MWOId);
                Model.BudgetItem = Budget;
            }
            Model.Id = MWOItemId;
            PreviousValues.CurrentMWOId = MWOId;


            await UpdateModel();
            loaded = true;
            StateHasChanged();


        }
       
        [Inject]
        public IMWOItemPrevisousValuesService PreviousValuesService { get; set; }
        public MWOItemPreviousValues PreviousValues { get; set; } = new();


        public MWOItemDialogData DialogData = new MWOItemDialogData();

        public async Task<bool> ShowTableDialog(CommandNozzle nozzle)
        {
            if (nozzle.Id == 0)
            {



            }

            var result = await DialogService.OpenAsync<NozzleDialog>($"Add new Nozzle ",
                   new Dictionary<string, object> { { "Nozzle", nozzle }, { "SaveDialog", false } });
            if (result == null) return false;

            return (bool)result;

        }
        async Task ReportDialog()
        {
            await Task.CompletedTask;
        }
        public void RefreshDialog()
        {
            StateHasChanged();
        }
        List<string> errors = new();
        protected bool errorVisible;
        async Task Save()
        {

            var result = await Service.AddUpdate(Model);
            if (result.Success)
            {
                await SaveOtherObjects();
                Model = result.ResponseObject;
                GoBack();
            }
            else
            {
                errors = result.ValidationErrors;

                errorVisible = true;
            }

        }
        async Task SaveOtherObjects()
        {
            switch (Model.Chapter.Id)
            {
                case 6:
                    await SavePipingItemObjects();
                    break;
            }
        }
        async Task SavePipingItemObjects()
        {

            await Service.VerifyNozzlesClosing(DialogData, Model);
        }
        public async Task UpdateModel()
        {
            if (Model.Id != 0)
            {
                Model = await Service.GetById(Model.Id);

                DialogData = await Service.GetMWOItemDataDialog();
                DialogData = await Service.GetMWOItemDataDialogByModel(DialogData, Model);

            }
            else
            {
                DialogData = await Service.GetMWOItemDataDialog();
            }

        }
        public async Task ChangeChapter()
        {
            if (Model.Id == 0)
            {
                PreviousValues.ChapterId = Model.Chapter.Id;
            }
            if (Model.BudgetItem)
                await AssignNomenclatore();
            DialogData = await Service.GetMWOItemDataDialogByChapter(DialogData, Model);
            DialogData = await Service.GetMWOItemDataDialogByChapterByModel(DialogData, Model);
            StateHasChanged();
        }

        public async Task AssignNomenclatore()
        {
            await Service.AssingNomenclatore(Model);
            RefreshDialog();
        }
        public async Task VerifiyePrevious()
        {
            CoincidenceEquipments = 0;
            if (Model.Id == 0)
            {
                CoincidenceEquipments = await PreviousValuesService.VerifyCoincidence(PreviousValues);
            }
            StateHasChanged();
        }
        async Task ShowDialogCoincidences()
        {
            MWOItemCommandResponse Response = await DialogService.OpenAsync<MWOItemsPreviousValues>("Equipment/Instruments Previous MWO´s",
                  new Dictionary<string, object> { { "Parameters", PreviousValues } },
               new DialogOptions() { Width = "1200px", Height = "750px", Resizable = true, Draggable = true, ShowClose = false });


            if (Response == null) return;

            if (Response.Success == true)
            {

                await Service.PassDataFoundToModel(Model, Response.ResponseObject);


            }

            await InvokeAsync(StateHasChanged);
            return;

        }
        void GoBack()
        {
            NavigationManager.NavigateTo($"/mwo-items/{MWOId}");
        }
        
    }
}
