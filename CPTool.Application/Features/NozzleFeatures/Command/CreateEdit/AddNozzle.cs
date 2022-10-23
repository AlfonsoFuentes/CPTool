

using CPTool.Application.Features.ConnectionTypeFeatures.CreateEdit;
using CPTool.Application.Features.EquipmentItemFeatures.CreateEdit;
using CPTool.Application.Features.GasketsFeatures.CreateEdit;
using CPTool.Application.Features.InstrumentItemFeatures.CreateEdit;
using CPTool.Application.Features.MaterialFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit;
using CPTool.Application.Features.PipeClassFeatures.CreateEdit;
using CPTool.Application.Features.PipeDiameterFeatures.CreateEdit;
using CPTool.Application.Features.PipingItemFeatures.CreateEdit;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTool.Application.Features.NozzleFeatures.CreateEdit
{
    public class AddNozzle : AddCommand
    {
       
        public int? PipeAccesoryId { get; set; }
        public int Order { get; set; }

        public int? ConnectedToId { get; set; }
        public int? EquipmentItemId { get; set; }
        public int? InstrumentItemId { get; set; }

        public int? PipingItemId { get; set; }

        public int? PipeDiameterId { get; set; }
        public int? ConnectionTypeId { get; set; }
        public int? nGasketId { get; set; }
        public int? nMaterialId { get; set; }
        public StreamType StreamType { get; set; }
        public int? nPipeClassId { get; set; }

    }
}
