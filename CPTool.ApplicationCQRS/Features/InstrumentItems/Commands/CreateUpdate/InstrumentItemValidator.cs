using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using System.Collections.Immutable;

namespace CPTool.ApplicationCQRS.Features.InstrumentItems.Commands.CreateUpdate
{
    public class InstrumentItemValidator : AbstractValidator<CommandMWOItem>
    {
        private readonly IRepositoryMWOItemWithInstrument _RepositoryMWOItem;
        public InstrumentItemValidator(IRepositoryMWOItemWithInstrument RepositoryMWOItem)
        {
            _RepositoryMWOItem = RepositoryMWOItem;
            RuleFor(p => p.InstrumentItem!.MeasuredVariable!.Id)
             .NotEqual(0).WithMessage("Measured Variable is required.");

        

            RuleFor(p => p.InstrumentItem!.TagNumber)
              .NotEmpty().WithMessage("Tag Number is required.")
               .NotNull().WithMessage("Tag Number is required.");

            RuleFor(e => e)
                .MustAsync(TagIdUnique)
                .WithMessage($"Tag Id already exists.");
            

           

        }

       
        private async Task<bool> TagIdUnique(CommandMWOItem e, CancellationToken token)
        {
            if (e.TagId == "") return true;
            var list = (await _RepositoryMWOItem.GetAllAsync(x => x.MWOId == e.MWOId && x.ChapterId == 7)).Select(x => x.InstrumentItem).ToImmutableList();

        

            return !list.Any(x => x.TagId == e.TagId);
        }
    }
}
