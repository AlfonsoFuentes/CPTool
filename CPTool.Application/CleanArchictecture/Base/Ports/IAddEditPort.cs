

namespace CPTool.ApplicationCA.Base.Ports
{
    public interface IAddEditPort<TAddDTO, TEditDTO, TEntity>
        where TAddDTO : AddCommand
        where TEditDTO : EditCommand
        where TEntity : BaseDomainModel
    {
        Task<Result<int>> Handle(TEditDTO DTO);
    }
}