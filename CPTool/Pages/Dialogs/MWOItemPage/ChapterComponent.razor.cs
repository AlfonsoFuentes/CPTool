

namespace CPTool.Pages.Dialogs.MWOItemPage
{
    public partial class ChapterComponent
    {
        [CascadingParameter]
        protected MWOItemDTO Model { get; set; }

        void OnValueChanged(int value)
        {
          
           var chapter = TablesService.ManChapter.List.FirstOrDefault(x => x.Id == value);
           
            Model.Letter = chapter.Letter;
            if (Model.Id == 0)
            {
                Model.ChapterDTO = chapter;

            }
            var list = Model.MWODTO.MWOItemDTOs.Where(x => x.ChapterDTO.Id == value).ToList();
          
            Model.Order = list.Count == 0 ? 1 : list.OrderBy(x => x.Order).Last().Order + 1;

        }
        private string ItemChapter(int arg)
        {
            if (arg == 0)
                return "Must select Chapter";
            return null;
        }
        string AnyName(string model)
        {

            if (model == null || model == "") return "Must define a name";
            if (TablesService.ManMWOItem.List.Where(x => x.Id != Model.Id).Any(x => x.Name == model)) return "Name already existing";


            return null;
        }
    }
}
