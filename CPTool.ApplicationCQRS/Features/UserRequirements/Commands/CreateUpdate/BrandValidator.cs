using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.UserRequirements.Commands.CreateUpdate
{
    public class UserRequirementValidator : AbstractValidator<CommandUserRequirement>
    {
        private readonly IRepositoryUserRequirement _UserRequirementRepository;
        public UserRequirementValidator(IRepositoryUserRequirement UserRequirementRepository)
        {
            _UserRequirementRepository = UserRequirementRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"MWO Type with the same name already exists.");

        }



        private async Task<bool> NameUnique(CommandUserRequirement e, CancellationToken token)
        {
            return !await _UserRequirementRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
