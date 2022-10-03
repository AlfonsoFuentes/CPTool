namespace CPTool.Application.Features.Base
{
    public class AddEditCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;

        public virtual AddEditCommand AddDetailtoMaster()
        {
            return null!;
        }
        public virtual void CreateMasterRelations(AddEditCommand Master1, AddEditCommand Master2)
        {
           
        }
        public virtual void SetParentId(int parentid)
        {

        }
    }
}
