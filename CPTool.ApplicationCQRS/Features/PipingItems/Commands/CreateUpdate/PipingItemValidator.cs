using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using System.Collections.Immutable;

namespace CPTool.ApplicationCQRS.Features.PipingItems.Commands.CreateUpdate
{
    public class PipingItemValidator : AbstractValidator<CommandMWOItem>
    {
        private readonly IRepositoryMWOItemWithPiping _RepositoryMWOItem;
        public PipingItemValidator(IRepositoryMWOItemWithPiping RepositoryMWOItem)
        {
            _RepositoryMWOItem = RepositoryMWOItem;

            //RuleFor(p => p.Name)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.PipingItem!.pMaterial!.Id)
                .NotEqual(0).WithMessage("Material is required.");

            RuleFor(p => p.PipingItem!.pMaterial!.Id)
            .NotEqual(0).WithMessage("Material is required.");
            RuleFor(p => p.PipingItem!.pProcessFluid!.Id)
            .NotEqual(0).WithMessage("Process Fluid is required.");
            RuleFor(p => p.PipingItem!.pDiameter!.Id)
            .NotEqual(0).WithMessage("Diameter is required.");
            RuleFor(p => p.PipingItem!.pPipeClass!.Id)
            .NotEqual(0).WithMessage("Pipe Class is required.");
            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"Tag Number already exists.");

            RuleFor(e => e)
                 .MustAsync(TagIdUnique)
                 .WithMessage($"Tag Id already exists.");

        }



        private async Task<bool> NameUnique(CommandMWOItem e, CancellationToken token)
        {
            if (e.PipingItem!.TagNumber == "") return true;
            var list = (await _RepositoryMWOItem.GetAllAsync(x => x.MWOId == e.MWOId && x.ChapterId == 6)).Select(y => y.PipingItem).ToImmutableList();
          
            return !list.Any(x => x!.TagNumber == e.EquipmentItem!.TagNumber);
        }
        private async Task<bool> TagIdUnique(CommandMWOItem e, CancellationToken token)
        {
            if (e.TagId == "") return true;
            var list = (await _RepositoryMWOItem.GetAllAsync(x => x.MWOId == e.MWOId && x.ChapterId == 6)).Select(y => y.PipingItem).ToImmutableList();

           

            return !list.Any(x => x!.TagId == e.TagId);
        }
    }
}
