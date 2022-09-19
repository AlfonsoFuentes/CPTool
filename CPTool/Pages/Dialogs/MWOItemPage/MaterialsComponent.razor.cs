﻿namespace CPTool.Pages.Dialogs.MWOItemPage
{
    public partial class MaterialsComponent
    {
        [Parameter]
        public MaterialsGroupDTO Model { get; set; } 
        private string ValidateGasket(string arg)
        {
            if (arg == null || arg == "")
                return null;
            if (!TablesService.ManGasket.List.Any(x => x.Name == arg))
                return $"Gasket: {arg} is not in the list";

            return null;
        }
        async Task UpdateGasket()
        {
            await TablesService.ManGasket.UpdateList();

            StateHasChanged();

        }
        private string ValidateMaterial(string arg)
        {
            if (arg == null || arg == "")
                return null;
            if (!TablesService.ManMaterial.List.Any(x => x.Name == arg))
                return $"Material: {arg} is not in the list";

            return null;
        }
        async Task UpdateMaterial()
        {
            await TablesService.ManMaterial.UpdateList();

            StateHasChanged();

        }
    }
}