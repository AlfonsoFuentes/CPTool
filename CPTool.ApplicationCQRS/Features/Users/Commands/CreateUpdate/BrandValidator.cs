using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.Users.Commands.CreateUpdate
{
    public class UserValidator : AbstractValidator<CommandUser>
    {
        private readonly IRepositoryUser _UserRepository;
        public UserValidator(IRepositoryUser UserRepository)
        {
            _UserRepository = UserRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"Name already exists.");

        }



        private async Task<bool> NameUnique(CommandUser e, CancellationToken token)
        {
            return !await _UserRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
