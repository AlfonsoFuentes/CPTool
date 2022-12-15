using CPTool.Application.Features.GasketsFeatures.CreateEdit;
using CPTool.Application.Features.InstrumentItemFeatures.CreateEdit;
using CPTool.Application.Features.MaterialFeatures.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.CreateEdit;
using CPTool.Application.Features.PipingItemFeatures.CreateEdit;
using CPTool.Domain.Enums;
using CPToolRadzen.Pages.Gaskets.Dialog;
using CPToolRadzen.Pages.Material.Dialog;
using Microsoft.AspNetCore.Components;

namespace CPToolRadzen.Pages.MWOItems.Dialog
{
    public partial class PipingDialog
    {
        [CascadingParameter]
        protected MWOItemDialog DialogParent { get; set; }
        protected EditPipingItem Model => DialogParent.Model.PipingItem;
        List<EditMWOItem> MWOItems => DialogParent.Model.MWO.MWOItems;
        List<EditNozzle> NozzlesStart => Model.StartMWOItem == null ? new() :
           FindNozzles(Model.StartMWOItem, Model.NozzleStart, StreamType.Outlet);
        List<EditNozzle> NozzlesFinish => Model.FinishMWOItem == null ? new() :
            FindNozzles(Model.FinishMWOItem, Model.NozzleFinish, StreamType.Inlet);

        List<EditMWOItem> MWOItemsStarts => FindMWOItems(Model.StartMWOItem, StreamType.Outlet);
        List<EditMWOItem> MWOItemsFinish => FindMWOItems(Model.FinishMWOItem, StreamType.Inlet);

        List<EditMWOItem> FindMWOItems(EditMWOItem mwoitem, StreamType type)
        {
            List<EditMWOItem> mwoitems = MWOItems.Where(x => x.ChapterId == 4 || x.ChapterId == 6 || x.ChapterId == 7).ToList();

            if (DialogParent.Model.Id != 0)
            {
                mwoitems = mwoitems.Where(x => x.Id != DialogParent.Model.Id).ToList();

            }
            List<EditMWOItem> mwoitemsresult = new();

            foreach (var row in mwoitems)
            {

                if (mwoitem != null && row.Id == mwoitem.Id)
                {
                    mwoitemsresult.Add(row);
                }
                else if (row.Nozzles.Count > 0 && row.Nozzles.Any(x => x.StreamType == type))
                {
                    var nozzles = row.Nozzles.Where(x => x.StreamType == type).ToList();
                    if (nozzles.Any(x => x.ConnectedToId == null))
                    {
                        mwoitemsresult.Add(row);
                    }
                }

            }

            return mwoitemsresult;
        }
        List<EditNozzle> FindNozzles(EditMWOItem mwoitem, EditNozzle nozzle, StreamType type)
        {

            List<EditNozzle> nozzles = new();
            if (nozzle != null && nozzle.ConnectedTo != null)
            {
                nozzles.Add(nozzle);
            }
            else if (mwoitem != null && mwoitem.Nozzles.Count > 0 && mwoitem.Nozzles.Any(x => x.StreamType == type))
            {
                nozzles = mwoitem.Nozzles.Where(x => x.StreamType == type).ToList();

                if (nozzles.Any(x => x.ConnectedToId == null))
                {
                    nozzles = nozzles.Where(x => x.ConnectedToId == null).ToList();
                }

            }

            return nozzles;
        }
        async Task<bool> ShowGasketDialog(EditGasket model)
        {

            var result = await DialogService.OpenAsync<GasketsDialog>(model.Id == 0 ? $"Add new Gasket" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
        public async Task<bool> ShowMaterialDialog(EditMaterial model)
        {

            var result = await DialogService.OpenAsync<MaterialDialog>(model.Id == 0 ? $"Add new Material" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
        void OnChangePipeClass()
        {
            if (Model.pPipeClass == null)
            {
                Model.pDiameter = null;

            }

        }
        async Task OnChangeEquipmentStart()
        {
            if (Model.NozzleStart != null)
            {
                Model.NozzleStart.ConnectedTo = null;
                await Mediator.Send(Model.NozzleStart);
                Model.NozzleStart = null;

            }

        }
        async Task OnChangeEquipmentFinish()
        {
            if (Model.NozzleFinish != null)
            {
                Model.NozzleFinish.ConnectedTo = null;
                await Mediator.Send(Model.NozzleFinish);
                Model.NozzleFinish = null;

            }

        }
        async Task OnChangeNozzleFinish()
        {

            if (Model.NozzleFinish != null)
            {
                Model.NozzleFinish.ConnectedTo = DialogParent.Model;
                await Mediator.Send(Model.NozzleFinish);

            }
            else
            {
                var nozzles = Model.FinishMWOItem.Nozzles.Where(x => x.StreamType == StreamType.Inlet && x.ConnectedTo != null).ToList();
                foreach (var row in nozzles)
                {
                    if (row.ConnectedTo != null && row.ConnectedTo.Id == DialogParent.Model.Id)
                    {
                        row.ConnectedTo = null;
                        await Mediator.Send(row);
                        break;
                    }
                }
            }

        }
        async Task OnChangeNozzleStart()
        {
            if (Model.NozzleStart != null)
            {
                Model.NozzleStart.ConnectedTo = DialogParent.Model;
                await Mediator.Send(Model.NozzleStart);
            }
            else
            {
                var nozzles = Model.StartMWOItem.Nozzles.Where(x => x.StreamType == StreamType.Outlet && x.ConnectedTo != null).ToList();
                foreach (var row in nozzles)
                {
                    if (row.ConnectedTo != null && row.ConnectedTo.Id == DialogParent.Model.Id)
                    {
                        row.ConnectedTo = null;
                        await Mediator.Send(row);
                        break;
                    }
                }
            }
        }
    }
}
