using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.StructuralItems.Commands.CreateUpdate
{
    public class StructuralItemValidator : AbstractValidator<CommandStructuralItem>
    {
        private readonly IRepositoryStructuralItem _StructuralItemRepository;
        public StructuralItemValidator(IRepositoryStructuralItem StructuralItemRepository)
        {
            _StructuralItemRepository = StructuralItemRepository;

            //RuleFor(p => p.Name)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            //RuleFor(e => e)
            //     .MustAsync(NameUnique)
            //     .WithMessage($"Name already exists.");

        }



        private async Task<bool> NameUnique(CommandStructuralItem e, CancellationToken token)
        {
            return !await _StructuralItemRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
