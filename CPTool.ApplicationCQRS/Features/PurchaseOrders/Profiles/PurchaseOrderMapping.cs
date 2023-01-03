global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.PurchaseOrders.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.PurchaseOrders.Profiles
{
    internal class PurchaseOrderMapping : Profile
    {
        public PurchaseOrderMapping()
        {
            CreateMap<PurchaseOrder, CommandPurchaseOrder>();
            CreateMap<CommandPurchaseOrder, PurchaseOrder>();
            CreateMap<AddPurchaseOrder, PurchaseOrder>();
            CreateMap<CommandPurchaseOrder, AddPurchaseOrder>();
            CreateMap<CommandPurchaseOrder, UpdatePurchaseOrder>();
            CreateMap<UpdatePurchaseOrder, PurchaseOrder>();
        }
    }
}
