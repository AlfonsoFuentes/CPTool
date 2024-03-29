﻿


using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.Domain.Entities;
using CPTool.InfrastructureCQRS.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CPTool.UIApp.AppPages.MWOItemsNew
{
    public partial class EquipmentDialogNew
    {
        [CascadingParameter]
        protected MWOItemDialogNew DialogParent { get; set; }
        protected CommandMWOItem Model => DialogParent.Model;
        protected MWOItemDialogData DialogData => DialogParent.DialogData;

        public Task UpdateDialog()
        {
            StateHasChanged();
            return Task.CompletedTask;
        }
        async Task ChangeBrand(int brandid)
        {
            Model.Supplier = new();
            DialogParent.PreviousValues.BrandId = brandid;
            await DialogParent.VerifiyePrevious();
            DialogData.Suppliers = await DialogParent.Service.GetSupliersByBrand(brandid);
        }
        async Task ChangeEquipmentType(int equipmenttypeid)
        {
            Model.EquipmentTypeSub = new();
            DialogParent.PreviousValues.EquipmentTypeId = equipmenttypeid;
            DialogParent.PreviousValues.EquipmentTypeSubId = 0;
            await DialogParent.VerifiyePrevious();
            DialogData.EquipmentTypeSubs = await DialogParent.Service.GetEquipmentTypeSubByEquipmentType(equipmenttypeid);
        }
        async Task ChangeEquipmentTypeSub(int equipmenttypeSubid)
        {

            DialogParent.PreviousValues.EquipmentTypeSubId = equipmenttypeSubid;
            await DialogParent.VerifiyePrevious();

        }
        async Task ChangeSupplier(int supplierid)
        {

            DialogParent.PreviousValues.SupplierId = supplierid;
            await DialogParent.VerifiyePrevious();

        }
        async Task ChangeOuterMaterial(int outermaterial)
        {

            DialogParent.PreviousValues.OuterMaterialId = outermaterial;
            await DialogParent.VerifiyePrevious();

        }
        async Task ChangeOuterInnerMaterial(int innermaterialid)
        {

            DialogParent.PreviousValues.InnerMaterialId = innermaterialid;
            await DialogParent.VerifiyePrevious();

        }

    }
}
