using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.Units.Commands.CreateUpdate
{
    public class UnitValidator : AbstractValidator<CommandUnit>
    {
        private readonly IRepositoryEntityUnit _UnitRepository;
        public UnitValidator(IRepositoryEntityUnit UnitRepository)
        {
            _UnitRepository = UnitRepository;

            //RuleFor(p => p.Name)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            //RuleFor(e => e)
            //     .MustAsync(NameUnique)
            //     .WithMessage($"Name already exists.");

        }



        private async Task<bool> NameUnique(CommandUnit e, CancellationToken token)
        {
            return !await _UnitRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
