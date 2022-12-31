using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.Materials.Commands.CreateUpdate
{
    public class MaterialValidator : AbstractValidator<CommandMaterial>
    {
        private readonly IRepositoryMaterial _MaterialRepository;
        public MaterialValidator(IRepositoryMaterial MaterialRepository)
        {
            _MaterialRepository = MaterialRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"MWO Type with the same name already exists.");

        }



        private async Task<bool> NameUnique(CommandMaterial e, CancellationToken token)
        {
            return !await _MaterialRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
