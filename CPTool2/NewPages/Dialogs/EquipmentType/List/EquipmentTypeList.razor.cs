using CPTool.Application.Features.EquipmentTypeFeatures.CreateEdit;
using CPTool.Application.Features.EquipmentTypeSubFeatures.CreateEdit;
using CPTool.Domain.Entities;
using CPTool2.Services;
using MediatR;
using Microsoft.AspNetCore.Components;
using MudBlazor;
namespace CPTool2.NewPages.Dialogs.EquipmentType.List
{
    public partial class EquipmentTypeList
    {
       
        EditEquipmentType SelectedEqu { get; set; } = new();
        EditEquipmentTypeSub SelectedEquSub { get; set; } = new();
        [Parameter]
        public RenderFragment OtherButtons { get; set; }


        List<EditEquipmentTypeSub> EquipmentSubs => SelectedEqu.Id==0?new(): GlobalTables.EquipmentTypeSubs.Where(x => x.EquipmentTypeId == SelectedEqu.Id).ToList();
    }
}
