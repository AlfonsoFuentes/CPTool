



using CPTool.Entities;
using CPTool.Shared;

namespace CPTool.Pages.Dialogs
{
    public partial class MWOPageDialog : CancellableComponent
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        //[Inject]
        //public IDTOManager<MWODTO, MWO> MWOmanager { get; set; }

        [Parameter]
        public MWODTO Model { get; set; }
        MudForm form;
        async Task Submit()
        {



            await form.Validate();
            if (form.IsValid)
            {
                //await MWOmanager.AddUpdate(Model, _cts.Token);

                MudDialog.Close(DialogResult.Ok(Model));
            }
        }


        void Cancel() => MudDialog.Cancel();


        protected override void OnInitialized()
        {
            success2 = true;

        }



        string AnyNumber(int number)
        {
            if (Model.Id == 0)
            {
                if (TablesService.ManMWO.List.Any(x => x.Number == number)) return "Number already existing";
            }
            else
            {
                if (TablesService.ManMWO.List.Where(x => x.Id != Model.Id).Any(x => x.Number == number)) return "Number already existing";
            }

            Regex extractNumberRegex = new Regex("\\d{5}$");

            if (!extractNumberRegex.IsMatch(number.ToString())) return "Enter a valid 5 digit";
            return null;
        }
    }
}