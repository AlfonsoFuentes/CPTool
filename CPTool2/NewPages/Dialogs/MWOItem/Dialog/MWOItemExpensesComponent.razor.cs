using CPTool.Application.Features.ChapterFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Domain.Entities;
using CPTool2.Services;
using MediatR;
using Microsoft.AspNetCore.Components;
using MudBlazor;
namespace CPTool2.NewPages.Dialogs.MWOItem.Dialog
{
    public partial class MWOItemExpensesComponent
    {
        [CascadingParameter]
        protected MWOItemDialog DialogParent { get; set; }
        protected EditMWOItem Model => DialogParent.Model;

        
        string ValidateUnitaryPrize(double valor)
        {

            if (valor < 0)
                return "Unitary prize must be greater than zero";
            return null;
        }
        string ValidateQuantity(double valor)
        {

            if (valor < 0)
                return "Quantity must be greater than zero";
            return null;
        }
        private string ValidateUnitaryPrizeName(string arg)
        {
            if (arg == null || arg == "")
                return "Must submit Unitary prize";
            if (!GlobalTables.UnitaryBasePrizes.Any(x => x.Name == arg))
                return $"Unitary prize: {arg} is not in the list";
            return null;
        }

    }
}
