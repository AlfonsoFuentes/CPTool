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

            RuleFor(p => p.PONumber)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.PurchaseRequisition)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.pSupplier!.Id)
       .NotEqual(0).WithMessage("Supplier is required.");

            RuleFor(p => p.pBrand!.Id)
      .NotEqual(0).WithMessage("Brand or Service is required.");

            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"Name already exists.");

        }



        private async Task<bool> NameUnique(CommandPurchaseOrder e, CancellationToken token)
        {
            return !await _PurchaseOrderRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
