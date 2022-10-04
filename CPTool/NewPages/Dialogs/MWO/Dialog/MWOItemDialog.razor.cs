using CPTool.Application.Features.ChapterFeatures.Command.CreateEdit;
using CPTool.Application.Features.ChapterFeatures.Query.GetList;
using CPTool.Application.Features.MWOFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOFeatures.Query.GetList;
using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.Query.GetList;

namespace CPTool.NewPages.Dialogs.MWO.Dialog
{
    public partial class MWOItemDialog
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = null!;
        [Parameter]
        public AddEditMWOItemCommand Model { get; set; } = null!;
        [Inject]
        public IMediator mediator { get; set; }
        GetChapterListQuery ChapterList = new();
        GetMWOItemListQuery MWOItemList = new();

        public List<AddEditChapterCommand> Chapters = new();
        public List<AddEditMWOItemCommand> MWOItems = new();
        [Parameter]
        public MudForm form { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            Chapters = await mediator.Send(ChapterList);
            MWOItems = await mediator.Send(MWOItemList);
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
       public string AnyName(string model)
        {

            if (model == null || model == "") return "Must define a name";
            if (Model.Id != 0)
            {
                if (MWOItems.Where(x => x.Id != Model.Id).Any(x => x.Name == model)) return "Name already existing";
            }
            else
            {
                if (MWOItems.Any(x => x.Name == model)) return "Name already existing";
            }



            return null;
        }
    }
}
