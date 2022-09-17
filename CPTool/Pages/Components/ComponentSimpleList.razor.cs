using CPTool.Interfaces;
using CPTool.Pages.Classes;

namespace CPTool.Pages.Components
{
    public partial class ComponentSimpleList<TDTO, T> : CancellableComponent, IDisposable
        where TDTO : AuditableEntityDTO, new()
        where T : AuditableEntity, new()
    {
        [Parameter]
        public IDTOManager<TDTO, T> Manager { get; set; }

        public Func<TDTO,string, bool> SearchFunc { get; set; } = null;

        ComponentTableList<TDTO, T> table;
        TDTO Selected = new();
        [Parameter]
        public string TableName { get; set; }

        [Parameter]
        public Func<TDTO, Task<DialogResult>> OnShowDialogOverrided { get; set; }

        protected override void OnInitialized()
        {

            TablesService.Save += OnSave;
            TablesService.Delete += OnDelete;
            base.OnInitialized();
        }
        async Task<DialogResult> ShowDialogOverrided(TDTO dto)
        {

            return OnShowDialogOverrided == null ? await ToolDialogService.ShowDialogName<TDTO>(dto) : await OnShowDialogOverrided.Invoke(dto);


        }

        async Task<IResult<IAuditableEntityDTO>> OnSave(IAuditableEntityDTO dto)
        {
            var result = await Manager.AddUpdate(dto as TDTO, _cts.Token);

            await Manager.UpdateList();
            StateHasChanged();
            return result;



        }
        async Task<IResult<int>> OnDelete(IAuditableEntityDTO dto)
        {
            var result = await Manager.Delete(dto.Id, _cts.Token);
            await Manager.UpdateList();
            StateHasChanged();
            return result;



        }
        void IDisposable.Dispose()
        {
            TablesService.Save -= OnSave;
            TablesService.Delete -= OnDelete;


        }
    }
}
