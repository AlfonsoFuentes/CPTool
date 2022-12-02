
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.Query.GetList;
using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderFeatures.Query.GetList;
using CPTool.Application.Features.PurchaseOrderItemFeature.Command.CreateEdit;
using CPTool.Application.Features.TaksFeatures.CreateEdit;
using CPTool.Application.Features.TaksFeatures.Query.GetList;

using static MudBlazor.CategoryTypes;

namespace CPTool.NewPages.Dialogs.MWO.List
{
    public partial class MWOList
    {
      
        EditMWO SelectedMaster { get; set; } = new();
     
       
      
        async Task CreateTaskMWO()
        {
            EditTaks editTaks = new EditTaks();
            editTaks.MWO = SelectedMaster;
            editTaks.TaksType = Domain.Entities.TaksType.Manual;
            var result=await ToolDialogService.ShowTaksDialog(editTaks);
            if(!result.Cancelled)
            {
                GetTaksListQuery getTaksListQuery = new GetTaksListQuery();
                GlobalTables.Takss=await Mediator.Send(getTaksListQuery);
            }
        }
      

        void GoToUserRequirmentPage()
        {
            NavigationManager.NavigateTo($"UserRequirementList/{SelectedMaster.Id}");
        }
        void GoToPurchaseOrderList()
        {
            NavigationManager.NavigateTo($"PurchaseOrderList/{SelectedMaster.Id}");
        }
        void GoToUserSignalList()
        {
            NavigationManager.NavigateTo($"SignaList/{SelectedMaster.Id}");
        }
        void GoToMWOItemList()
        {
            NavigationManager.NavigateTo($"MWOItemList/{SelectedMaster.Id}");
        }
        void GoToControlLoopList()
        {
            NavigationManager.NavigateTo($"ControlLoopList/{SelectedMaster.Id}");
        }
       
        //const string SPREADSHEET_ID = "1nh3CjxLeytSi9EBr6gy3-kHu5zCNAMdwAAndDo6Aj6A";
        //SpreadsheetsResource.ValuesResource _googleSheetValues;
        //const string SHEET_NAME = "Test";
        void OnExcel()
        {
            //var file = googleSheetsHelper.CreateSheet("Mwolist");
            //_googleSheetValues = googleSheetsHelper.Service.Spreadsheets.Values;
            //var range = $"{SHEET_NAME}!A:D";
            //var valueRange = new ValueRange
            //{
            //    Values = ItemsMapper.MapToRangeData(SelectedMaster)
            //};
            //var appendRequest = _googleSheetValues.Append(valueRange, SPREADSHEET_ID, range);
            //appendRequest.ValueInputOption = AppendRequest.ValueInputOptionEnum.USERENTERED;
            //appendRequest.Execute();
        }
    }
}
