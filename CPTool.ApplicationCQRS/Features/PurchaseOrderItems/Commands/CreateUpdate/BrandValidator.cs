using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.PurchaseOrderItems.Commands.CreateUpdate
{
    public class PurchaseOrderItemValidator : AbstractValidator<CommandPurchaseOrderItem>
    {
        private readonly IRepositoryPurchaseOrderItem _Repository;
        public PurchaseOrderItemValidator(IRepositoryPurchaseOrderItem Repository)
        {
            _Repository = Repository;

            //RuleFor(p => p.Name)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.PrizeCurrency)
        .NotEqual(0).WithMessage("Value is required.");

            RuleFor(p => p.MWOItem!.Id)
       .NotEqual(0).WithMessage("Item is required.");

            //RuleFor(e => e)
            //     .MustAsync(NameUnique)
            //     .WithMessage($"Name already exists.");

        }



        private async Task<bool> NameUnique(CommandPurchaseOrderItem e, CancellationToken token)
        {
            var result = await _Repository.Any(x => x.Id != e.Id && x.Name == e.Name);
            return !result;
        }
    }
}
