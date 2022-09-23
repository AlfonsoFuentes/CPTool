namespace CPTool.Interfaces
{
    public interface ICreationMethod<TDTO, T> where TDTO : IAuditableEntityDTO, new()
          where T : IAuditableEntity
    {

        TDTO CreateDTO();
    }
}
