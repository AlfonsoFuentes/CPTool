
using CPTool.Application.Features.ChapterFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;

namespace CPTool.ApplicationCA.Base.Ports
{
    public interface IListPort<TEditDTO, TEntity>
        where TEditDTO : EditCommand
        where TEntity : BaseDomainModel
    {
        Task<List<TEditDTO>> Handle();
        bool FilterFunc(TEditDTO element, string searchString);

    }
    public interface IListChapter: IListPort<EditChapter, Chapter>
    {

    }
    public interface IListMWOType : IListPort<EditMWOType, MWOType>
    {

    }
    public interface IListMWO : IListPort<EditMWO, MWO>
    {

    }
}