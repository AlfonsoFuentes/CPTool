using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.MWOItems.Queries.GetList
{
    public class GetMWOItemsPreviousValuesListQuery : IRequest<List<CommandMWOItem>>
    {
        public int CurrentMWOId { get; set; }
        public bool Budget { get; set; } = false;
        public int ChapterId { get; set; }

        public int EquipmentTypeId { get; set; }

        public int EquipmentTypeSubId { get; set; }
        public int MeasuredVariableId { get; set; }
        public int MeasuredVariableModifierId { get; set; }
        public int ReadoutId { get; set; }
        public int DeviceFunctionId { get; set; }
        public int DeviceFunctionModifierId { get; set; }
        public int BrandId { get; set; }
        public int SupplierId { get; set; }
        public int InnerMaterialId { get; set; }
        public int OuterMaterialId { get; set; }

    }
}
