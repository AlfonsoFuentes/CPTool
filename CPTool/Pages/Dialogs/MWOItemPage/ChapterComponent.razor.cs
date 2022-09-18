

namespace CPTool.Pages.Dialogs.MWOItemPage
{
    public partial class ChapterComponent
    {
        [CascadingParameter]
        protected MWOItemDialog Dialog { get; set; }
        protected MWOItemDTO Model => Dialog.Model;

       
        void OnChapterChanged()
        {
          
            var list = Model.MWODTO.MWOItemDTOs.Where(x => x.ChapterDTO.Id == Model.ChapterDTO.Id).ToList();
          
            Model.Order = list.Count == 0 ? 1 : list.OrderBy(x => x.Order).Last().Order + 1;

            Dialog.ChapterChange();
            StateHasChanged();
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
            if(Model.Id!=0)
            {
                if (TablesService.ManMWOItem.List.Where(x => x.Id != Model.Id).Any(x => x.Name == model)) return "Name already existing";
            }
            else
            {
                if (TablesService.ManMWOItem.List.Any(x => x.Name == model)) return "Name already existing";
            }
           


            return null;
        }
    }
}
