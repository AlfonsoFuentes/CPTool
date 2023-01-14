using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Nozzles.Commands.CreateUpdate;
using CPTool.ApplicationCQRSResponses;
using CPTool.UIApp.AppPages.Nozzles;
using CPTool.InfrastructureCQRS.Services;
using Microsoft.AspNetCore.Components;
using Radzen;
using System.Xml.Linq;

namespace CPTool.UIApp.AppPages.MWOItems
{
    public partial class MWOItemDialog
    {
        [Inject]
        public IMWOItemPrevisousValuesService PreviousValuesService { get; set; }
        public MWOItemPreviousValues PreviousValues { get; set; } = new();
        public bool Budget => Model.BudgetItem;
        [Inject]
        public IMWOItemService Service { get; set; }
        [Parameter]
        public CommandMWOItem Model { get; set; } = new();
        public MWOItemDialogData DialogData = new MWOItemDialogData();
        protected override async Task OnInitializedAsync()
        {
            PreviousValues.CurrentMWOId = Model.MWO.Id;
            DialogData = await Service.GetMWOItemDataDialog();
            await UpdateModel();

            Service.ShowDialog = ShowTableDialog;

        }
        public async Task<bool> ShowTableDialog(CommandNozzle nozzle)
        {
            if (nozzle.Id == 0)
            {

                //nozzle.Name = Model.GetNozzleName();

            }
           
           var result=await  DialogService.OpenAsync<NozzleDialog>($"Add new Nozzle ",
                  new Dictionary<string, object> { { "Nozzle", nozzle }, { "SaveDialog", false } });
            if (result == null) return false;
            if ((bool)result == true)
            {
                //if (Model.Id == 0) Model.Nozzles.Add(nozzle);


                //await DialogParent.UpdateModel();

            }
            return (bool)result;
            
        }
        public void RefreshDialog()
        {
            StateHasChanged();
        }
        async Task<BaseResponse> Save()
        {

            var result = await Service.AddUpdate(Model);
            if (result.Success)
            {
                await SaveOtherObjects();
                Model = result.ResponseObject;
            }

            return result;
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
            //var model = Model.PipingItem;
            await Service.VerifyNozzlesClosing(DialogData, Model);
        }
        public async Task UpdateModel()
        {
            if (Model.Id != 0)
            {
              
                Model = await Service.GetById(Model.Id);
              
                DialogData = await Service.GetMWOItemDataDialogByModel(DialogData, Model);
               
            }
            StateHasChanged();
        }
        public async Task ChangeChapter()
        {
            if (Model.Id == 0)
            {
                PreviousValues.ChapterId = Model.Chapter.Id;
            }
            Model.AssignInternalItem();
            DialogData = await Service.GetMWOItemDataDialogByChapter(DialogData, Model);
            DialogData = await Service.GetMWOItemDataDialogByChapterByModel(DialogData, Model);
            StateHasChanged();
        }
        int CoincidenceEquipments = 0;

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
            var result = await DialogService.OpenAsync<MWOItemsPreviousValues>("Equipment/Instruments Previous MWO´s",
                  new Dictionary<string, object> { { "Parameters", PreviousValues } },
               new DialogOptions() { Width = "1200px", Height = "750px", Resizable = true, Draggable = true });


            if (result == null) return;

            MWOItemCommandResponse Response = result as MWOItemCommandResponse;

            Model.BudgetPrize = Response.ResponseObject.Assigned;
            Model.Model = Response.ResponseObject.Model;
            Model.Reference=Response.ResponseObject.Reference;
            Model.EquipmentType = Response.ResponseObject.EquipmentType;
            Model.EquipmentTypeSub=Response.ResponseObject.EquipmentTypeSub;
            Model.MeasuredVariable=Response.ResponseObject.MeasuredVariable;
            Model.MeasuredVariableModifier = Response.ResponseObject.MeasuredVariableModifier;
            Model.DeviceFunction=Response.ResponseObject.DeviceFunction;
            Model.DeviceFunctionModifier = Response.ResponseObject.DeviceFunctionModifier;
            Model.Readout=Response.ResponseObject.Readout;
            Model.InnerMaterial=Response.ResponseObject.InnerMaterial;
            //Model.OutMaterial=Response.MWOItemObject.OutMaterial;
            Model.Brand=Response.ResponseObject.Brand;
            Model.Supplier=Response.ResponseObject.Supplier;

            StateHasChanged();


        }
    }
}
