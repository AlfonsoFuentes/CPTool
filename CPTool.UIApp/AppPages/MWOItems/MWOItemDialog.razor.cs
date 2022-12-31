using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate;
using CPTool.ApplicationCQRSResponses;
using CPTool.UIApp.Services;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.MWOItems
{
    public partial class MWOItemDialog
    {
        [Inject]
        public IMWOItemService Service { get; set; }
        [Parameter]
        public CommandMWOItem Model { get; set; } = new();
        public MWOItemDialogData DialogData = new MWOItemDialogData();
        protected override async Task OnInitializedAsync()
        {
            DialogData = await Service.GetMWOItemDataDialog();
            await UpdateModel();



        }
        async Task<BaseResponse> Save()
        {

            var result = await Service.AddUpdate(Model);
            if (result.Success)
            {
                await SaveOtherObjects();
                Model = result.MWOItemObject;
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
            var model = Model.PipingItem;
            await Service.VerifyNozzlesClosing(DialogData, Model);
        }
        public async Task UpdateModel()
        {
            if (Model.Id != 0)
            {
                Model = await Service.GetById(Model.Id);
                DialogData = await Service.GetMWOItemDataDialogByModel(DialogData, Model);
                var result = await Service.VerifyProcessCondition(Model);
            }

        }
        public async Task ChangeChapter()
        {
            Model.AssignInternalItem();
            DialogData = await Service.GetMWOItemDataDialogByChapter(DialogData, Model);
            DialogData = await Service.GetMWOItemDataDialogByChapterByModel(DialogData, Model);
            StateHasChanged();
        }
    }
}
