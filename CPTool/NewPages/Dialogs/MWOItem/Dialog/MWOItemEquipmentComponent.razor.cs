﻿using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.ChapterFeatures.CreateEdit;
using CPTool.Application.Features.EquipmentItemFeatures.CreateEdit;
using CPTool.Application.Features.EquipmentTypeSubFeatures.Query.GetList;
using CPTool.Application.Features.GasketsFeatures.CreateEdit;
using CPTool.Application.Features.MaterialFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.CreateEdit;
using CPTool.Domain.Entities;

namespace CPTool.NewPages.Dialogs.MWOItem.Dialog
{
    public partial class MWOItemEquipmentComponent
    {
        [CascadingParameter]
        protected MWOItemDialog DialogParent { get; set; }
        protected EditEquipmentItem Model => DialogParent.Model.EquipmentItem;
       
      
       

        private string ValidateEquipmentType(string arg)
        {
            if (arg == null || arg == "")
                return "Must submit Equipment Type";
            if (!GlobalTables.EquipmentTypes.Any(x => x.Name == arg))
                return $"Equipment Type: {arg} is not in the list";
            return null;
        }
        private string ValidateEquipmentSubType(string arg)
        {
            if (arg == null || arg == "")
                return null;
            if (Model.eEquipmentTypeId!=null&&!GlobalTables.EquipmentTypeSubs.Where(x=>x.EquipmentTypeId==Model.eEquipmentTypeId).Any(x => x.Name == arg))
                return $"Equipment Sub Type: {arg} is not in the list";
            return null;
        }
        void BrandChanged(EditBrand brand)
        {

            Model.eSupplier = new();
            StateHasChanged();
        }
       void EquipmentTypeChanged(EditEquipmentType eq)
        {
            if (eq==null||eq.Id==0)
            {
                Model.eEquipmentType = new();

                Model.eEquipmentTypeSub = new();
            }
            else if (eq.Id != Model.eEquipmentTypeId)
            {
                Model.eEquipmentType = eq;
              
                Model.eEquipmentTypeSub = new();

            }
            StateHasChanged();
        }
        async Task UpdateEquipmentTypeSub()
        {
            if (Model.eEquipmentType.Id != 0)
            {
                GetEquipmentTypeListQuery queryListEq = new();
                GlobalTables.EquipmentTypes = await Mediator.Send(queryListEq);
                GetEquipmentTypeSubListQuery queryList = new();
                GlobalTables.EquipmentTypeSubs = await Mediator.Send(queryList);
                GetByIdEquipmentTypeQuery query = new() { Id= Model.eEquipmentType.Id };
                Model.eEquipmentType = await Mediator.Send(query);
               
               StateHasChanged();
            }

        }
      
        EditEquipmentType EquipmentParent => Model.eEquipmentType == null ? null : GlobalTables.EquipmentTypes.FirstOrDefault(x => x.Id == Model.eEquipmentType.Id);
    }
}
