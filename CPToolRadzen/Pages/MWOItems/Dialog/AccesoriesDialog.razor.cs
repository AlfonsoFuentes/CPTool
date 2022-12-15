using CPTool.Application.Features.MaterialFeatures.CreateEdit;
using CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit;

using CPTool.Application.Features.PipeClassFeatures.CreateEdit;
using CPTool.Application.Features.PipeDiameterFeatures.CreateEdit;
using CPTool.Application.Features.PipingItemFeatures.CreateEdit;

using CPToolRadzen.Pages.PipeAccesory.Dialog;
using Microsoft.AspNetCore.Components;


namespace CPToolRadzen.Pages.MWOItems.Dialog
{
    public partial class AccesoriesDialog
    {
        [CascadingParameter]
        protected MWOItemDialog DialogParent { get; set; }
        protected EditPipingItem Model => DialogParent.Model.PipingItem;
        List<EditPipeAccesory> FilteredList => GetFilteredList();
        EditPipeClass PipeClassSelected = new();
        EditPipeDiameter PipeDiameterSelected = new();
        EditMaterial PipeMaterialSelected = new();
        List<EditPipeAccesory> GetFilteredList()
        {
            var retorno = RadzenTables.PipeAccesorys.Where(x => x.pPipingItem == null&& x.pPipingItemId == Model.Id).ToList();
            if (PipeClassSelected.Id != 0)
            {
                retorno = retorno.Where(x => x.Nozzles.Any(y => y.nPipeClassId == PipeClassSelected.Id)).ToList();
            }
            if (PipeDiameterSelected.Id != 0)
            {
                retorno = retorno.Where(x => x.Nozzles.Any(y => y.PipeDiameterId == PipeDiameterSelected.Id)).ToList();
            }
            if (PipeMaterialSelected.Id != 0)
            {
                retorno = retorno.Where(x => x.Nozzles.Any(y => y.nMaterialId == PipeMaterialSelected.Id)).ToList();
            }
            return retorno;
        }
        void RemoveItem()
        {
            Model.PipeAccesorys.Remove(SelectedItemAdded);
        }

        void AddItem(EditPipeAccesory SelectedItem)
        {
            EditPipeAccesory model = new();
            model.pPipingItem = Model;

            model.SectionType = SelectedItem.SectionType;

            Model.PipeAccesorys.Add(model);
        }
        public async Task<bool> ShowPipeAccesoryDialog(EditPipeAccesory model)
        {

            var result = await DialogService.OpenAsync<PipeAccesoryDialog>(model.Id == 0 ? $"Add new Accesory" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
        protected override void OnInitialized()
        {
            base.OnInitialized();
            PipeClassSelected = Model.pPipeClass;
            PipeDiameterSelected = Model.pDiameter;
            PipeMaterialSelected = Model.pMaterial;
        }
        EditPipeAccesory SelectedItemAdded = new();
        EditPipeAccesory SelectedItemToAdd = new();
        async Task AddNewAccesory()
        {
            EditPipeAccesory model = new();
            model.paPipeClass = PipeClassSelected;
            model.paDiameter = PipeDiameterSelected;
            model.paMaterial = PipeMaterialSelected;
            var result = await ShowPipeAccesoryDialog(model);
            if (result)
            {
              


            }
        }
    }
}
