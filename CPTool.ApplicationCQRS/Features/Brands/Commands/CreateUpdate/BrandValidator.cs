using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

            RuleFor(p=>p.BrandType)
                .NotEqual(Domain.Enums.BrandType.None)
                .WithMessage("Brand or Service Type must be defined.");

            RuleFor(e => e)
            .MustAsync(NameUnique)
                 .WithMessage("Name already exists.");

        }



        private async Task<bool> NameUnique(CommandBrand e, CancellationToken token)
        {
            return !await _BrandRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
