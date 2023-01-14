using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOs.Queries.Export;
using CPTool.ApplicationCQRS.Responses;
using CPTool.ApplicationCQRSFeatures.MWOItems.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.MWOs.Commands.Delete;
using CPTool.ApplicationCQRSFeatures.MWOs.Queries.GetDetail;
using CPTool.ApplicationCQRSFeatures.MWOs.Queries.GetList;
using CPTool.ApplicationCQRSFeatures.MWOTypes.Queries.GetList;
using MediatR;

namespace CPTool.InfrastructureCQRS.Services
{
    public class MWOItemPreviousValues
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
    public interface IMWOItemPrevisousValuesService
    {


        Task<List<CommandMWOItem>> GetAll(MWOItemPreviousValues data);
        Task<int> VerifyCoincidence(MWOItemPreviousValues data);
    }
    public class MWOItemPrevisousValuesService : IMWOItemPrevisousValuesService
    {
        protected readonly IMediator mediator;

        public MWOItemPrevisousValuesService(IMediator mediator)
        {
            this.mediator = mediator;
        }



        public async Task<List<CommandMWOItem>> GetAll(MWOItemPreviousValues data)
        {
            GetMWOItemsPreviousValuesListQuery command = new()
            {
                Budget = false,
                CurrentMWOId = data.CurrentMWOId,
                EquipmentTypeId = data.EquipmentTypeId,
                EquipmentTypeSubId = data.EquipmentTypeSubId,
                DeviceFunctionModifierId = data.DeviceFunctionModifierId,
                DeviceFunctionId = data.DeviceFunctionId,
                MeasuredVariableModifierId = data.MeasuredVariableModifierId,
                MeasuredVariableId = data.MeasuredVariableId,
                ReadoutId = data.ReadoutId,
                ChapterId = data.ChapterId,
                BrandId = data.BrandId,
                SupplierId = data.SupplierId,
                InnerMaterialId = data.InnerMaterialId,
                OuterMaterialId = data.OuterMaterialId,

            };

            return await mediator.Send(command);
        }
        public async Task<int> VerifyCoincidence(MWOItemPreviousValues data)
        {
            GetMWOItemsPreviousValuesListQuery command = new()
            {
                Budget = false,
                CurrentMWOId = data.CurrentMWOId,
                EquipmentTypeId = data.EquipmentTypeId,
                EquipmentTypeSubId = data.EquipmentTypeSubId,
                DeviceFunctionModifierId = data.DeviceFunctionModifierId,
                DeviceFunctionId = data.DeviceFunctionId,
                MeasuredVariableModifierId = data.MeasuredVariableModifierId,
                MeasuredVariableId = data.MeasuredVariableId,
                ReadoutId = data.ReadoutId,
                ChapterId = data.ChapterId,
                BrandId = data.BrandId,
                SupplierId = data.SupplierId,
                InnerMaterialId = data.InnerMaterialId,
                OuterMaterialId = data.OuterMaterialId,

            };
            var list = await mediator.Send(command);
            return list.Count;
        }

    }
}