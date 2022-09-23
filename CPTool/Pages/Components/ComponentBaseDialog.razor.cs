namespace CPTool.Pages.Components
{
    public partial class ComponentBaseDialog<TDTO> where TDTO : AuditableEntityDTO
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public RenderFragment Components { get; set; }

        [Parameter]
        public TDTO Model { get; set; }

        [Parameter]
        public Func<Task> FuncBeforeClose { get; set; }
        [Parameter]
        public Func<Task> FuncOnInitialize { get; set; }
        [Parameter]
        public MudForm form { get; set; }
        [Parameter]
        public string ButtonSaveName { get; set; }
        [Parameter]
        public bool DisableButtonSave { get; set; }
        protected override async Task OnInitializedAsync()
        {
            if(FuncOnInitialize!=null) await FuncOnInitialize.Invoke(); 
           
        }
        public async virtual Task Submit()
        {
            await form.Validate();
            if (form.IsValid)
            {

                if (FuncBeforeClose != null) await FuncBeforeClose.Invoke();

                MudDialog.Close(DialogResult.Ok(Model));
            }
        }

        void Cancel() => MudDialog.Cancel();
    }
}
