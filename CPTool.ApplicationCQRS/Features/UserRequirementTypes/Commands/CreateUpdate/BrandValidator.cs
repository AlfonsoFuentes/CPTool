using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.UserRequirementTypes.Commands.CreateUpdate
{
    public class UserRequirementTypeValidator : AbstractValidator<CommandUserRequirementType>
    {
        private readonly IRepositoryUserRequirementType _UserRequirementTypeRepository;
        public UserRequirementTypeValidator(IRepositoryUserRequirementType UserRequirementTypeRepository)
        {
            _UserRequirementTypeRepository = UserRequirementTypeRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"Name already exists.");

        }



        private async Task<bool> NameUnique(CommandUserRequirementType e, CancellationToken token)
        {
            return !await _UserRequirementTypeRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
