global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.PurchaseOrderItems.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.PurchaseOrderItems.Profiles
{
    internal class PurchaseOrderItemMapping : Profile
    {
        public PurchaseOrderItemMapping()
        {
            CreateMap<PurchaseOrderItem, CommandPurchaseOrderItem>();
            CreateMap<CommandPurchaseOrderItem, PurchaseOrderItem>();
            CreateMap<AddPurchaseOrderItem, PurchaseOrderItem>();
            CreateMap<CommandPurchaseOrderItem, AddPurchaseOrderItem>();
        }
    }
}
