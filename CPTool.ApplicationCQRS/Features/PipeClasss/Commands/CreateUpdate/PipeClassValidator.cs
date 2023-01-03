using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.PipeClasss.Commands.CreateUpdate
{
    public class PipeClassValidator : AbstractValidator<CommandPipeClass>
    {
        private readonly IRepositoryPipeClass _PipeClassRepository;
        public PipeClassValidator(IRepositoryPipeClass PipeClassRepository)
        {
            _PipeClassRepository = PipeClassRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"Name already exists.");

        }



        private async Task<bool> NameUnique(CommandPipeClass e, CancellationToken token)
        {
            return !await _PipeClassRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
