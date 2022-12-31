global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.DownPayments.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.DownPayments.Profiles
{
    internal class DownPaymentMapping : Profile
    {
        public DownPaymentMapping()
        {
            CreateMap<DownPayment, CommandDownPayment>();
            CreateMap<CommandDownPayment, DownPayment>();
            CreateMap<AddDownPayment, DownPayment>();
            CreateMap<CommandDownPayment, AddDownPayment>();
        }
    }
}
