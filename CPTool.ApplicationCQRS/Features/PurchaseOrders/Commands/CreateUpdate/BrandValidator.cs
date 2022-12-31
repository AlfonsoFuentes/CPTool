using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.PurchaseOrders.Commands.CreateUpdate
{
    public class PurchaseOrderValidator : AbstractValidator<CommandPurchaseOrder>
    {
        private readonly IRepositoryPurchaseOrder _PurchaseOrderRepository;
        public PurchaseOrderValidator(IRepositoryPurchaseOrder PurchaseOrderRepository)
        {
            _PurchaseOrderRepository = PurchaseOrderRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"MWO Type with the same name already exists.");

        }



        private async Task<bool> NameUnique(CommandPurchaseOrder e, CancellationToken token)
        {
            return !await _PurchaseOrderRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
