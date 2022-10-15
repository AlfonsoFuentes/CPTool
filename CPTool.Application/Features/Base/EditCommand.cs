

namespace CPTool.Application.Features.Base
{
    public class EditCommand : AddCommand
    {
        public int Id { get; set; }


       
        public virtual T AddDetailtoMaster<T>() where T : AddCommand, new()
        {
            return null!;
        }
        public virtual void CreateMasterRelations<T1, T2>(T1 Master1, T2 Master2)
            where T1 : EditCommand, new()
            where T2 : EditCommand, new()
        {

        }



    }
}
