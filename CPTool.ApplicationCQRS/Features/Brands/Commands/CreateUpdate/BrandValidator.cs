using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.Brands.Commands.CreateUpdate
{
    public class BrandValidator : AbstractValidator<CommandBrand>
    {
        private readonly IRepositoryBrand _BrandRepository;
        public BrandValidator(IRepositoryBrand BrandRepository)
        {
            _BrandRepository = BrandRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"MWO Type with the same name already exists.");

        }



        private async Task<bool> NameUnique(CommandBrand e, CancellationToken token)
        {
            return !await _BrandRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
