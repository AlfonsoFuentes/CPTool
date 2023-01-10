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
        private readonly IRepositoryBrand _Repository;
        public BrandValidator(IRepositoryBrand Repository)
        {
            _Repository = Repository;

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
            var result = await _Repository.Any(x => x.Id != e.Id && x.Name == e.Name);
            return !result;
        }
    }
}
