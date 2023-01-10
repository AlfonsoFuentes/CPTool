using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.ProcessFluids.Commands.CreateUpdate
{
    public class ProcessFluidValidator : AbstractValidator<CommandProcessFluid>
    {
        private readonly IRepositoryProcessFluid _Repository;
        public ProcessFluidValidator(IRepositoryProcessFluid Repository)
        {
            _Repository = Repository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.TagLetter)
               .NotEmpty().WithMessage("Abbreviation is required.")
               .NotNull()
               .MaximumLength(50).WithMessage("Abbreviation must not exceed 50 characters.");

            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"Name with the same name already exists.");
            RuleFor(e => e)
              .MustAsync(AbbreviationUnique)
              .WithMessage($"Abbreviation with the same name already exists.");

        }



        private async Task<bool> NameUnique(CommandProcessFluid e, CancellationToken token)
        {
            var result = await _Repository.Any(x => x.Id != e.Id && x.Name == e.Name);
            return !result;
        }
        private async Task<bool>AbbreviationUnique(CommandProcessFluid e, CancellationToken token)
        {
            var result = await _Repository.Any(x => x.Id != e.Id && x.TagLetter == e.TagLetter);
            return !result;
          
        }
    }
}
