using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.PropertyPackages.Commands.CreateUpdate
{
    public class PropertyPackageValidator : AbstractValidator<CommandPropertyPackage>
    {
        private readonly IRepositoryPropertyPackage _PropertyPackageRepository;
        public PropertyPackageValidator(IRepositoryPropertyPackage PropertyPackageRepository)
        {
            _PropertyPackageRepository = PropertyPackageRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"MWO Type with the same name already exists.");

        }



        private async Task<bool> NameUnique(CommandPropertyPackage e, CancellationToken token)
        {
            return !await _PropertyPackageRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
