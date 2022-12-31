using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.FieldLocations.Commands.CreateUpdate
{
    public class FieldLocationValidator : AbstractValidator<CommandFieldLocation>
    {
        private readonly IRepositoryFieldLocation _FieldLocationRepository;
        public FieldLocationValidator(IRepositoryFieldLocation FieldLocationRepository)
        {
            _FieldLocationRepository = FieldLocationRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"MWO Type with the same name already exists.");

        }



        private async Task<bool> NameUnique(CommandFieldLocation e, CancellationToken token)
        {
            return !await _FieldLocationRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
