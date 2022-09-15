



using AutoMapper;
using CPTool.Entities;
using CPTool.Shared;

namespace CPTool.Pages.Dialogs
{
    public partial class MWOPageDialog : CancellableComponent
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }



        [Parameter]
        public MWODTO Model { get; set; }

       
        MudForm form;
        async Task Submit()
        {



            await form.Validate();
            if (form.IsValid)
            {
               
                MudDialog.Close(DialogResult.Ok(Model));
            }
        }


        void Cancel() => MudDialog.Cancel();
        private string ReviewMWOType(string arg)
        {
            if (arg == null || arg == "")
                return "Must submit MWO Type";
            return null;
        }
        private string ReviewMWOName(string arg)
        {
            if (arg == null || arg == "")
                return "Must submit MWO Name";
            if (TablesService.ManMWO.List.Any(x => x.Name == arg))
            {
                
                return $"MWO Name: {arg} is already existing in MWO List";
            }
            return null;
        }
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