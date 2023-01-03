using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.PipeAccesorys.Commands.CreateUpdate
{
    public class PipeAccesoryValidator : AbstractValidator<CommandPipeAccesory>
    {
        private readonly IRepositoryPipeAccesory _PipeAccesoryRepository;
        public PipeAccesoryValidator(IRepositoryPipeAccesory PipeAccesoryRepository)
        {
            _PipeAccesoryRepository = PipeAccesoryRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"Name already exists.");

        }



        private async Task<bool> NameUnique(CommandPipeAccesory e, CancellationToken token)
        {
            return !await _PipeAccesoryRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
