using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.MeasuredVariables.Commands.CreateUpdate
{
    public class MeasuredVariableValidator : AbstractValidator<CommandMeasuredVariable>
    {
        private readonly IRepositoryMeasuredVariable _MeasuredVariableRepository;
        public MeasuredVariableValidator(IRepositoryMeasuredVariable MeasuredVariableRepository)
        {
            _MeasuredVariableRepository = MeasuredVariableRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"Name already exists.");

        }



        private async Task<bool> NameUnique(CommandMeasuredVariable e, CancellationToken token)
        {
            return !await _MeasuredVariableRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
