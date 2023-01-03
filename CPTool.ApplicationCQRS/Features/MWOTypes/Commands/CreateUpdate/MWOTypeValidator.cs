using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.MWOTypes.Commands.CreateUpdate
{
    public class MWOTypeValidator : AbstractValidator<CommandMWOType>
    {
        private readonly IRepositoryMWOType _MWOTypeRepository;
        public MWOTypeValidator(IRepositoryMWOType MWOTypeRepository)
        {
            _MWOTypeRepository = MWOTypeRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"Name already exists.");

        }



        private async Task<bool> NameUnique(CommandMWOType e, CancellationToken token)
        {
            return !await _MWOTypeRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
