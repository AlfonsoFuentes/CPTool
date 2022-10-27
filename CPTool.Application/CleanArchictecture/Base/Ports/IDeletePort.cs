

namespace CPTool.ApplicationCA.Base.Ports
{
    public interface IDeletePort<TDeleteDTO, TEntity>
        where TDeleteDTO : DeleteCommand
         where TEntity : BaseDomainModel
    {
        Task<Result<int>> Handle(TDeleteDTO request);
    }
}