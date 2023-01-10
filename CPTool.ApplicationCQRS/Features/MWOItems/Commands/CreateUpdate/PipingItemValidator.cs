using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;
using System.Collections.Immutable;

namespace CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate
{
    public class PipingItemValidator : AbstractValidator<CommandMWOItem>
    {
        private readonly IRepositoryMWOItem _Repository;
        public PipingItemValidator(IRepositoryMWOItem Repository)
        {
            _Repository = Repository;


            RuleFor(p => p.MaterialPiping!.Id)
                .NotEqual(0).WithMessage("Material is required.")
                  .When(x => x.BudgetItem == false);



            RuleFor(p => p.ProcessFluid!.Id)
            .NotEqual(0).WithMessage("Process Fluid is required.")
              .When(x => x.BudgetItem == false);

            RuleFor(p => p.Diameter!.Id)
            .NotEqual(0).WithMessage("Diameter is required.")
              .When(x => x.BudgetItem == false);

            RuleFor(p => p.PipeClass!.Id)
            .NotEqual(0).WithMessage("Pipe Class is required.")
              .When(x => x.BudgetItem == false);

            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"Tag Number already exists.")
                   .When(x => x.BudgetItem == false);

            RuleFor(e => e)
                 .MustAsync(TagIdUnique)
                 .WithMessage($"Tag Id already exists.")

                .When(x => x.BudgetItem == false);

        }



        private async Task<bool> NameUnique(CommandMWOItem e, CancellationToken token)
        {
            if (e.TagNumber == "") return true;
            var result = await _Repository.Any(x => x.Id != e.Id && x.MWOId == e.MWOId && x.ChapterId == e.ChapterId && x.TagNumber == e.TagNumber);
            return !result;

           
        }
        private async Task<bool> TagIdUnique(CommandMWOItem e, CancellationToken token)
        {
            if (e.TagId == "") return true;

            var result = await _Repository.Any(x => x.Id != e.Id && x.MWOId == e.MWOId && x.ChapterId == e.ChapterId && x.TagId == e.TagId);
            return !result;


           
        }
    }
}
