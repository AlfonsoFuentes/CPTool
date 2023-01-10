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
        private readonly IRepositoryMWO _Repository;
        public MWOValidator(IRepositoryMWO Repository)
        {
            _Repository = Repository;

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
            var result = await _Repository.Any(x => x.Id != e.Id && x.Name == e.Name);
            return !result;
        }
    }
}
