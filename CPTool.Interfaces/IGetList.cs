namespace CPTool.Interfaces
{
    public interface IGetList<TDTO, in T>
        where TDTO : IAuditableEntityDTO
          where T : IAuditableEntity
    {
        Task<List<TDTO>> Handle();
    }

}
