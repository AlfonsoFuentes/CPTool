namespace CPTool.Application.Features.Base
{
    public class AddEditCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;

        public AddEditCommand Parent { get; set; } = null!;
        public  T AddDetailtoMaster<T>() where T: AddEditCommand,new()
        {
            T detail = new();
            detail.Parent = this;
            return detail;
        }
        public virtual void CreateMasterRelations<T1,T2>(T1 Master1, T2 Master2)
            where T1: AddEditCommand,new()
            where T2: AddEditCommand,new()
        {
           
        }
        
        
    }
}
