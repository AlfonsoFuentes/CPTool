using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.ProcessConditions.Commands.CreateUpdate
{
    public class ProcessConditionValidator : AbstractValidator<CommandProcessCondition>
    {
        private readonly IRepositoryProcessCondition _ProcessConditionRepository;
        public ProcessConditionValidator(IRepositoryProcessCondition ProcessConditionRepository)
        {
            _ProcessConditionRepository = ProcessConditionRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"MWO Type with the same name already exists.");

        }



        private async Task<bool> NameUnique(CommandProcessCondition e, CancellationToken token)
        {
            return !await _ProcessConditionRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
