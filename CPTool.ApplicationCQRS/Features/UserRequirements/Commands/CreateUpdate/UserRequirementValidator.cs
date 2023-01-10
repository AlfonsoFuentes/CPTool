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
        private readonly IRepositoryUserRequirement _Repository;
        public UserRequirementValidator(IRepositoryUserRequirement Repository)
        {
            _Repository = Repository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.MWO!.Id)
         .NotEqual(0).WithMessage("MWO is required.");
            RuleFor(p => p.RequestedBy!.Id)
       .NotEqual(0).WithMessage("Requested By is required.");

            RuleFor(p => p.UserRequirementType!.Id)
    .NotEqual(0).WithMessage("Requested By is required.");
            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"Name already exists.");

        }



        private async Task<bool> NameUnique(CommandUserRequirement e, CancellationToken token)
        {
            var result = await _Repository.Any(x => x.Id != e.Id && x.Name == e.Name);
            return !result;
        }
    }
}
