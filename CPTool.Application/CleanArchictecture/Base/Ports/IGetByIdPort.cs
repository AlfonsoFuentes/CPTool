

namespace CPTool.ApplicationCA.Base.Ports
{
    public interface IGetByIdPort<TEditDTO, TEntity>
         where TEditDTO : EditCommand
        where TEntity : BaseDomainModel
    {
        Task<TEditDTO> Handle(int DTO);
    }
}