



using AutoMapper;

using CPTool.Shared;
using static MudBlazor.FilterOperator;

namespace CPTool.Pages.Dialogs
{
    //public partial class MWOPageDialog : CancellableComponent
    //{
      



    //    [Parameter]
    //    public MWODTO Model { get; set; }

       
       
    //    private string ReviewMWOType(string arg)
    //    {
    //        if (arg == null || arg == "")
    //            return "Must submit MWO Type";
    //        return null;
    //    }
    //    private string ReviewMWOName(string arg)
    //    {
    //        if (arg == null || arg == "")
    //            return "Must submit MWO Name";
    //        if (Model.Id == 0)
    //        {
    //            if (TablesService.MWOs.Any(x => x.Name == arg)) return $"MWO Name: {arg} is already existing in MWO List";
    //        }
    //        else
    //        {
    //            if (TablesService.MWOs.Where(x => x.Id != Model.Id).Any(x => x.Name == arg)) return $"MWO Name: {arg} is already existing in MWO List";
    //        }
            
    //        return null;
    //    }
        
    //    string AnyNumber(int number)
    //    {
    //        if (Model.Id == 0)
    //        {
    //            if (TablesService.MWOs.Any(x => x.Number == number)) return "Number already existing";
    //        }
    //        else
    //        {
    //            if (TablesService.MWOs.Where(x => x.Id != Model.Id).Any(x => x.Number == number)) return "Number already existing";
    //        }

    //        Regex extractNumberRegex = new Regex("\\d{5}$");

    //        if (!extractNumberRegex.IsMatch(number.ToString())) return "Enter a valid 5 digit";
    //        return null;
    //    }
    //}
}