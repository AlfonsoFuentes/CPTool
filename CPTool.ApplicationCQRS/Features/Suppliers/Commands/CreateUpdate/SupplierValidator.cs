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



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"MWO Type with the same name already exists.");

        }



        private async Task<bool> NameUnique(CommandSupplier e, CancellationToken token)
        {
            return !await _SupplierRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
