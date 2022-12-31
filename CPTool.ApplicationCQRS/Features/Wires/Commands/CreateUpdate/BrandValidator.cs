using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.Wires.Commands.CreateUpdate
{
    public class WireValidator : AbstractValidator<CommandWire>
    {
        private readonly IRepositoryWire _WireRepository;
        public WireValidator(IRepositoryWire WireRepository)
        {
            _WireRepository = WireRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"MWO Type with the same name already exists.");

        }



        private async Task<bool> NameUnique(CommandWire e, CancellationToken token)
        {
            return !await _WireRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
