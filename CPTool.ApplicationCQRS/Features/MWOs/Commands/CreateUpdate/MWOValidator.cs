using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate
{
    public class MWOValidator : AbstractValidator<CommandMWO>
    {
        private readonly IRepositoryMWO _MWORepository;
        public MWOValidator(IRepositoryMWO MWORepository)
        {
            _MWORepository = MWORepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(customer => customer.Number.ToString())
                .Matches("^[0-9]{5}$").WithMessage("Number must be 5 digits.");

            RuleFor(customer => customer.Number)
                .NotEqual(0).WithMessage("{PropertyName} is required.")
               ;


            RuleFor(p => p.MWOType!.Id)
          .NotEqual(0).WithMessage("MWO type is required.");

            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"Name already exists.");

        }



        private async Task<bool> NameUnique(CommandMWO e, CancellationToken token)
        {
            return !await _MWORepository.IsPropertyUnique(e.Id, "Name", e.Name);
        }
    }
}
