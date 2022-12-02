
using CPTool.Application.Features.TaksFeatures.CreateEdit;
using CPTool.Domain.Entities;

namespace CPToolRadzen.Pages.Taks.Dialog
{
    public partial class TaksDialog : DialogTemplate<EditTaks>
    {
        protected override void OnInitialized()
        {
            FilteredList = Model.Id == 0 ? RadzenTables.Takss : RadzenTables.Takss.Where(x => x.Id != Model.Id).ToList();
        }
        bool ButtonSaveDisable => Model.TaksType == TaksType.Automatic ? true :
          Model.TaksStatus == TaksStatus.Completed ? true : false;
        string ButtonSaveName => Model.TaksType == TaksType.Manual ?
            Model.TaksStatus == TaksStatus.Draft ? "Create" : "Close" : "Automatic";
        public async  Task Submit()
        {
            if (SaveDialog)
            {
                if (Model.TaksType == TaksType.Manual)
                {
                    if (Model.TaksStatus == TaksStatus.Draft)
                    {
                        Model.TaksStatus = TaksStatus.Pending;

                    }
                    else if (Model.TaksStatus == TaksStatus.Pending)
                    {
                        Model.TaksStatus = TaksStatus.Completed;
                        Model.CompletionDate = DateTime.Now;
                    }




                }
                var result = await CommandQuery.AddUpdate(Model);

                DialogService.Close(result.Succeeded);
            }
            else
            {
                DialogService.Close(true);
            }
            
        }
    }
}
