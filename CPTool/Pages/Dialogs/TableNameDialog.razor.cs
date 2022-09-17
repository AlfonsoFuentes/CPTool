


namespace CPTool.Pages.Dialogs
{
    public partial class TableNameDialog<T> where T : AuditableEntityDTO, new()
    {

       
       
        [Parameter]
        public T Model { get; set; }
       
    }
}
