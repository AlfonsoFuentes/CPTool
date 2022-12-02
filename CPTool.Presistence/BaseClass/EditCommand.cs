
using System.Net;

namespace CPTool.Persistence.BaseClass
{
    public class EditCommand :IRequest<Result<int>>
    {


        public virtual string TableName=>typeof(EditCommand).Name.Substring(4);
        public int Id { get; set; }
        public virtual string Name { get; set; } = string.Empty;
        public virtual T AddDetailtoMaster<T>() where T : EditCommand, new()
        {
            return null!;
        }
        public virtual void CreateMasterRelations<T1, T2>(T1 Master1, T2 Master2)
            where T1 : EditCommand, new()
            where T2 : EditCommand, new()
        {

        }
        public virtual void SetMaster<T1, T2>(T1 Master1, T2 Master2)
             where T1 : EditCommand, new()
            where T2 : EditCommand, new()
        {

        }
        public virtual void SetDetail<T1, T2>(T1 Master1, T2 Master2)
             where T1 : EditCommand, new()
            where T2 : EditCommand, new()
        {

        }
    }
    public class MasterDetailCommand 
    {
        public virtual int? MasterId { get; }
        public virtual int? DetailId { get; }


        public virtual void CreateMasterRelations<T1, T2>(T1 Master1, T2 Master2)
            where T1 : EditCommand, new()
            where T2 : EditCommand, new()
        {

        }


    }
}
