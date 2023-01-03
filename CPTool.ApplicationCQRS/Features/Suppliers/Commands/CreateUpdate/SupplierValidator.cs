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
        private readonly IRepositorySupplier _SupplierRepository;
        public SupplierValidator(IRepositorySupplier SupplierRepository)
        {
            _SupplierRepository = SupplierRepository;

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
            return !await _SupplierRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
        private async Task<bool> VendorCodeUnique(CommandSupplier e, CancellationToken token)
        {
            return !await _SupplierRepository.IsPropertyUnique(e.Id, "VendorCode", e.VendorCode);
        }
    }
}
