using CPTool.Application.Features.MWOFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOFeatures.Query.GetList;
using System.Text.RegularExpressions;

namespace CPTool.NewPages.Dialogs.MWO.Dialog
{
    public partial class MWODialog
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = null!;
        [Parameter]
        public AddEditMWOCommand Model { get; set; } = null!;
        [Inject]
        public IMediator mediator { get; set; }
        public GetMWOListQuery MWOList = new();
        public GetMWOTypeListQuery MWOTypeList = new();

        public List<AddEditMWOCommand> MWOs = new();
        public List<AddEditMWOTypeCommand> MWOTypes = new();
        [Parameter]
        public MudForm form { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            MWOs = await mediator.Send(MWOList);
            MWOTypes = await mediator.Send(MWOTypeList);
        }

        public async virtual Task Submit()
        {
            await Validateform();
            if (form.IsValid)
            {

                var result = await mediator.Send(Model);

                MudDialog.Close(DialogResult.Ok(Model));
            }
        }

        void Cancel() => MudDialog.Cancel();
        async Task Validateform()
        {
            await form.Validate();
        }
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
            if (Model.Id == 0)
            {
                if (MWOs.Any(x => x.Name == arg)) return $"MWO Name: {arg} is already existing in MWO List";
            }
            else
            {
                if (MWOs.Where(x => x.Id != Model.Id).Any(x => x.Name == arg)) return $"MWO Name: {arg} is already existing in MWO List";
            }

            return null;
        }

        string AnyNumber(int number)
        {
            if (Model.Id == 0)
            {
                if (MWOs.Any(x => x.Number == number)) return "Number already existing";
            }
            else
            {
                if (MWOs.Where(x => x.Id != Model.Id).Any(x => x.Number == number)) return "Number already existing";
            }

            Regex extractNumberRegex = new Regex("\\d{5}$");

            if (!extractNumberRegex.IsMatch(number.ToString())) return "Enter a valid 5 digit";
            return null;
        }
    }
}