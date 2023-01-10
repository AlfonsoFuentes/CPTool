using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.ControlLoops.Commands.CreateUpdate
{
    public class ControlLoopValidator : AbstractValidator<CommandControlLoop>
    {
        private readonly IRepositoryControlLoop _Repository;
        public ControlLoopValidator(IRepositoryControlLoop Repository)
        {
            _Repository = Repository;

            RuleFor(p => p.ProcessVariable!.Id)
               .NotEqual(0).WithMessage("Process Variable is required.")
                .NotNull()
                ;
            RuleFor(p => p.ControlledVariable!.Id)
              .NotEqual(0).WithMessage("Controlled Variable is required.")
               .NotNull()
               ;
            RuleFor(p => p.FailType)
               .NotEqual( FailType.None)
               .WithMessage("Fail Type must be defined.");
            RuleFor(p => p.ActionType)
              .NotEqual(ActionType.None)
              .WithMessage("Action Type must be defined.");
            //RuleFor(e => e)
            //     .MustAsync(NameUnique)
            //     .WithMessage($"Name already exists.");

        }



        private async Task<bool> NameUnique(CommandControlLoop e, CancellationToken token)
        {
            var result = await _Repository.Any(x => x.Id != e.Id  && x.Name == e.Name);
            return !result;
           
        }
    }
}
