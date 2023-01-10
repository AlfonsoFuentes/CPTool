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
        private readonly IRepositoryPurchaseOrder _Repository;
        public PurchaseOrderValidator(IRepositoryPurchaseOrder Repository)
        {
            _Repository = Repository;

            RuleFor(p => p.PONumber)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is required.")
                .Length(10).WithMessage("{PropertyName} must be 10 characters.")
                .Must(PONumber => PONumber.StartsWith("850")).WithMessage("{PropertyName} must start with 850.")
                .When(x => x.Id != 0);

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
            var result = await _Repository.Any(x => x.Id != e.Id && x.Name == e.Name);
            return !result;
        }
    }
}
