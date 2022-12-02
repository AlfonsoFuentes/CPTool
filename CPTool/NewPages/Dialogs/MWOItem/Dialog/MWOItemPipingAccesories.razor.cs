using CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit;
using CPTool.Application.Features.PipeAccesoryFeatures.Query.GetList;
using CPTool.Application.Features.PipingItemFeatures.CreateEdit;
using System.Runtime.CompilerServices;

namespace CPTool.NewPages.Dialogs.MWOItem.Dialog
{
    public partial class MWOItemPipingAccesories
    {
        [CascadingParameter]
        protected MWOItemDialog DialogParent { get; set; }
        protected EditPipingItem Model => DialogParent.Model.PipingItem;

        EditPipeAccesory SelectedItemAdded = new();
        EditPipeAccesory SelectedItemToAdd = new();
        List<EditPipeAccesory> FilteredList => GetFilteredList();
        EditPipeClass PipeClassSelected = new();
        EditPipeDiameter PipeDiameterSelected = new();
        EditMaterial PipeMaterialSelected = new();
        List<EditPipeAccesory> GetFilteredList()
        {
            var retorno = GlobalTables.PipeAccesorys.Where(x => x.pPipingItem == null).ToList();
            if (PipeClassSelected.Id != 0)
            {
                retorno = retorno.Where(x => x.Nozzles.Any(y => y.nPipeClassId == PipeClassSelected.Id)).ToList();
            }
            if (PipeDiameterSelected.Id != 0)
            {
                retorno = retorno.Where(x => x.Nozzles.Any(y => y.PipeDiameterId == PipeDiameterSelected.Id)).ToList();
            }
            if(PipeMaterialSelected.Id!=0)
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

        protected override void OnInitialized()
        {
            base.OnInitialized();
            PipeClassSelected = Model.pPipeClass;
            PipeDiameterSelected = Model.pDiameter;
            PipeMaterialSelected=Model.pMaterial;
        }
        async Task AddNewAccesory()
        {
            EditPipeAccesory model = new();
            model.paPipeClass = PipeClassSelected;
            model.paDiameter = PipeDiameterSelected;
            model.paMaterial = PipeMaterialSelected;
            var result = await ToolDialogService.ShowPipeAccesory(model);
            if (!result.Cancelled)
            {
                GetPipeAccesoryListQuery getPipeAccesoryListQuery = new();
                GlobalTables.PipeAccesorys = await Mediator.Send(getPipeAccesoryListQuery);


            }
        }
    }
}
