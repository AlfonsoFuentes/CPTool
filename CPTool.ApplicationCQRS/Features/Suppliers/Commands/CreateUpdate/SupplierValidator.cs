using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.Suppliers.Commands.CreateUpdate
{
    public class SupplierValidator : AbstractValidator<CommandSupplier>
    {
        private readonly IRepositorySupplier _Repository;
        public SupplierValidator(IRepositorySupplier Repository)
        {
            _Repository = Repository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
            RuleFor(p => p.Phone)
             .NotEmpty().WithMessage("{PropertyName} is required.")
             .NotNull()
             .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.ContactPerson)
             .NotEmpty().WithMessage("{PropertyName} is required.")
             .NotNull()
             .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.TaxCodeLP!.Id)
           .NotEqual(0).WithMessage("Tax Code LP is required.");

            RuleFor(p => p.TaxCodeLD!.Id)
         .NotEqual(0).WithMessage("Tax Code LD is required.");

            RuleFor(customer => customer.Email).EmailAddress().WithMessage("Must supply valid email."); ;


            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"Name already exists.");
            RuleFor(e => e)
                .MustAsync(VendorCodeUnique)
                .WithMessage($"Vendor Code already exists.");
        }



        private async Task<bool> NameUnique(CommandSupplier e, CancellationToken token)
        {
            var result = await _Repository.Any(x => x.Id != e.Id && x.Name == e.Name);
            return !result;
        }
        private async Task<bool> VendorCodeUnique(CommandSupplier e, CancellationToken token)
        {
            var result = await _Repository.Any(x => x.Id != e.Id && x.VendorCode == e.VendorCode);
            return !result;
           
        }
    }
}
